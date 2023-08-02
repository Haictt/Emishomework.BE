using AutoMapper;
using DPHai.Fresher032023.EmisHomework.BL.App.Interfaces;
using DPHai.Fresher032023.EmisHomework.Common;
using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using DPHai.Fresher032023.EmisHomework.Common.Enums;
using DPHai.Fresher032023.EmisHomework.Common.Exceptions;
using DPHai.Fresher032023.EmisHomework.Common.UnitOfWork;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.BL.App.AppServices
{
    public class ExerciseService : BaseService<Exercise, GetExerciseDto, Exercise, Filter>, IExerciseService
    {
        protected readonly IExerciseRepository _exerciseRepository;
        protected readonly IQuestionRepository _questionRepository;
        protected readonly IAnswerRepository _answerRepository;
        protected readonly IGradeRepository _gradeRepository;
        protected readonly ISubjectRepository _subjectRepository;
        protected readonly ITopicRepository _topicRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository, IGradeRepository gradeRepository, ISubjectRepository subjectRepository, ITopicRepository topicRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(exerciseRepository, unitOfWork, mapper)
        {
            _exerciseRepository = exerciseRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _gradeRepository = gradeRepository;
            _subjectRepository = subjectRepository;
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Hàm lấy toàn bộ bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter">bộ lọc</param>
        /// <returns></returns>
        public async Task<IEnumerable<GetExerciseDto>> GetAllExerciseAsync(Filter filter)
        {
            var exercises = await _exerciseRepository.GetAllExerciseAsync(filter);
            return _mapper.Map<IEnumerable<GetExerciseDto>>(exercises);
        }

        /// <summary>
        /// Hàm lấy tổng số bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter">bộ lọc</param>
        /// <returns></returns>
        public async Task<int> GetTotalExerciseAsync(Filter filter)
        {
            return await _exerciseRepository.GetTotalExerciseAsync(filter);
        }

        /// <summary>
        /// Hàm lấy 1 bài tập theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<GetExerciseDto> GetOneAsync(Guid id)
        {
            return await _exerciseRepository.GetOneAsync(id);
        }

        /// <summary>
        /// Hàm thêm mới hoặc cập nhật 1 bài tập
        /// </summary>
        /// <param name="exercise">bài tập</param>
        /// <returns></returns>
        public async Task<Guid?> UpsertExerciseAsync(PostExerciseDto exercise)
        {
            /// Logic là: Nếu có update field là exercise -> chưa có Id (tức là thêm mới) thì thêm và lấy id trả về, có Id (sửa bài tập) thì lấy luôn id này
            /// Nếu có update field question, gán id của exercise cho question trước tiên -> Nếu k có id question (tức là lưu nháp) thì thêm và lấy id trả về, có id (sửa câu hỏi) thì lấy luôn id này
            /// Nếu có update field answer (1 là thêm câu hỏi thì có, 2 là sao chép câu hỏi, 3 là sửa nhưng sửa cả câu trả lời) -> Xóa hết câu trả lời theo id câu hỏi ở trên, rồi thêm lại toàn bộ câu trả lời được gửi 
            try
            {
                var updatedFields = exercise.UpdateFields;
                var exerciseId = exercise.ExerciseId;
                Guid? questionId = null;


                if (updatedFields.Count == 0)
                {
                    return exerciseId;
                }
                else
                {
                    await _unitOfWork.BeginTransactionAsync();
                    if (updatedFields.Contains("Exercise") && await IsExerciseValid(exercise))
                    {
                        if (exerciseId == null)
                        {
                            exerciseId = await _exerciseRepository.PostAsync(_mapper.Map<Exercise>(exercise));

                        }
                        else
                        {
                            await _exerciseRepository.UpdateAsync(_mapper.Map<Exercise>(exercise));
                        }

                    }
                    if (updatedFields.Contains("Question"))
                    {

                        questionId = exercise.Questions[exercise.Questions.Count - 1].QuestionId;
                        var question = exercise.Questions[exercise.Questions.Count - 1];
                        question.ExerciseId = exerciseId;
                        if (questionId == null)
                        {
                            questionId = await _questionRepository.PostAsync(_mapper.Map<Question>(question));
                        }
                        else
                        {
                            await _questionRepository.UpdateAsync(_mapper.Map<Question>(question));
                        }
                    }
                    if (updatedFields.Contains("Answer") && await IsAnswersValid(exercise.Questions[exercise.Questions.Count - 1].Answers, exercise.Questions[exercise.Questions.Count - 1].QuestionType))
                    {
                        var answers = exercise.Questions[exercise.Questions.Count - 1].Answers;

                        await _answerRepository.DeleteAnswerByQuestionAsync(questionId);

                        if (answers.Count > 0)
                        {
                            foreach (var answer in answers)
                            {
                                answer.QuestionId = questionId;
                            }
                            await _answerRepository.PostMultipleAsync(_mapper.Map<IList<Answer>>(answers));
                        }

                    }
                    await _unitOfWork.CommitAsync();
                }

                return exerciseId;

            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw new InternalException(MISAResource.Internal_Exception);
            }

        }

        /// <summary>
        /// Hàm validate dữ liệu bài tập
        /// </summary>
        /// <param name="exercise">Bài tập</param>
        /// <returns></returns>
        /// <exception cref="ValidateException"></exception>
        public async Task<bool> IsExerciseValid(PostExerciseDto exercise)
        {
            var grade = await _gradeRepository.GetOneAsync(exercise.GradeId);

            if (grade == null)
            {
                throw new ValidateException(MISAResource.Validate_Exception);
            }

            var subject = await _subjectRepository.GetOneAsync(exercise.SubjectId);

            if (subject == null)
            {
                throw new ValidateException(MISAResource.Validate_Exception);
            }

            var topics = await _topicRepository.GetAllTopicByGradeAndSubjectAsync(exercise.GradeId, exercise.SubjectId);

            if (exercise.TopicId != null && !topics.Any(topicId => topicId.TopicId == exercise.TopicId))
            {
                throw new ValidateException(MISAResource.Validate_Exception);
            }
            return true;
        }

        /// <summary>
        /// Hàm validate danh sách câu trả lời
        /// </summary>
        /// <param name="answers">List câu trả lời</param>
        /// <param name="questionType">Loại câu chỏi</param>
        /// <returns></returns>
        /// <exception cref="ValidateException"></exception>
        public async Task<bool> IsAnswersValid(List<PostAnswerDto?> answers, QuestionType questionType)
        {
            if(questionType == QuestionType.Write)
            {
                return true;
            }
            else
            {
                if (questionType != QuestionType.Write && answers.Count == 0)
                {
                    throw new ValidateException(MISAResource.Validate_Exception);
                }
                else if (answers.All(answer => answer.AnswerStatus == AnswerStatus.False))
                {
                    throw new ValidateException(MISAResource.Validate_Exception);
                }
            }
           
            return true;
        }

    }
}
