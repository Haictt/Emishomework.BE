using Dapper;
using DPHai.Fresher032023.EmisHomework.Common.Dto;
using DPHai.Fresher032023.EmisHomework.Common.Entity;
using DPHai.Fresher032023.EmisHomework.Common.UnitOfWork;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DPHai.Fresher032023.EmisHomework.DL.Repository
{
    public class ExerciseRepository : BaseRepository<Exercise, Filter>, IExerciseRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        public ExerciseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Hàm lấy toàn bộ bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Exercise>> GetAllExerciseAsync(Filter filter)
        {
            var sql = "SELECT e.ExerciseId, e.ExerciseName, e.ExerciseImage, e.GradeId, e.SubjectId, e.TopicId, e.ExerciseStatus, e.ExerciseTag , COUNT(q.QuestionId) AS TotalQuestion FROM exercise e LEFT JOIN question q ON q.ExerciseId = e.ExerciseId WHERE ";
            var properties = typeof(Filter).GetProperties();
            var dynamicParams = new DynamicParameters();

            foreach (var property in properties)
            {
                object? propertyValue = property.GetValue(filter);

                if (propertyValue != null && propertyValue.ToString() != "")
                {
                    if (property.Name == "SearchField")
                    {
                        sql += $"(e.ExerciseName LIKE CONCAT('%' , @p_SearchField , '%') OR e.ExerciseTag LIKE CONCAT('%' , @p_SearchField , '%')) AND ";
                        dynamicParams.Add("p_SearchField", propertyValue.ToString());
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        sql += $"e.{property.Name} = @p_{property.Name} AND ";
                        dynamicParams.Add($"p_{property.Name}", propertyValue.ToString());
                    }
                    else
                    {
                        if (property.Name != "Offset" && property.Name != "Limit")
                        {
                            sql += $"e.{property.Name} = @p_{property.Name} AND ";
                            dynamicParams.Add($"p_{property.Name}", propertyValue);
                        }
                    }
                }
            }

            // Remove the trailing "AND " if any
            if (sql.EndsWith("AND "))
            {
                sql = sql.Remove(sql.Length - 4); // Remove the last 4 characters ("AND ")
            }
            else
            {
                // If no conditions were added, remove the "WHERE" clause
                sql = sql.Replace("WHERE ", "");
            }

            sql += "GROUP BY e.ExerciseId ORDER BY e.CreatedDate DESC ";
            sql += "LIMIT @p_Offset, @p_Limit; ";

            // Add Limit and Offset parameters for pagination
            dynamicParams.Add("p_Limit", filter.Limit);
            dynamicParams.Add("p_Offset", filter.Offset);

            var entities = await _unitOfWork.Connection.QueryAsync<Exercise>(sql, dynamicParams);
            return entities;


        }

        /// <summary>
        /// Hàm lấy tổng số bài tập theo bộ lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<int> GetTotalExerciseAsync(Filter filter)
        {
            var sql = "SELECT COUNT(1) FROM exercise e WHERE ";
            var properties = typeof(Filter).GetProperties();
            var dynamicParams = new DynamicParameters();

            foreach (var property in properties)
            {
                object? propertyValue = property.GetValue(filter);

                if (propertyValue != null && propertyValue.ToString() != "")
                {
                    if (property.Name == "SearchField")
                    {
                        sql += $"(e.ExerciseName LIKE CONCAT('%' , @p_SearchField , '%') OR e.ExerciseTag LIKE CONCAT('%' , @p_SearchField , '%')) AND ";
                        dynamicParams.Add("p_SearchField", propertyValue.ToString());
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        sql += $"e.{property.Name} = @p_{property.Name} AND ";
                        dynamicParams.Add($"p_{property.Name}", propertyValue.ToString());
                    }
                    else
                    {
                        if (property.Name != "Offset" && property.Name != "Limit")
                        {
                            sql += $"e.{property.Name} = @p_{property.Name} AND ";
                            dynamicParams.Add($"p_{property.Name}", propertyValue);
                        }
                    }
                }
            }

            // Remove the trailing "AND " if any
            if (sql.EndsWith("AND "))
            {
                sql = sql.Remove(sql.Length - 4); // Remove the last 4 characters ("AND ")
            }
            else
            {
                // If no conditions were added, remove the "WHERE" clause
                sql = sql.Replace("WHERE ", "");
            }

            sql += "; ";

            var total = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<int>(sql, dynamicParams);
            return total;

        }

        /// <summary>
        /// Hàm lấy 1 bài tập
        /// </summary>
        /// <param name="id">id bài tập</param>
        /// <returns></returns>
        new public async Task<GetExerciseDto> GetOneAsync(Guid id)
        {
            var query = "Proc_GetExerciseById";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add("p_ExerciseId", id);
            // Use Dapper's Query method with relationship mapping
            var lookup = new Dictionary<Guid, GetExerciseDto>();
            await _unitOfWork.Connection.QueryAsync<GetExerciseDto, GetQuestionDto, GetAnswerDto, GetExerciseDto>(
                query,
                (exercise, question, answer) =>
                {
                    if (!lookup.TryGetValue(exercise.ExerciseId, out var exerciseEntry))
                    {
                        exerciseEntry = exercise;
                        exerciseEntry.Questions = new List<GetQuestionDto>();
                        lookup.Add(exerciseEntry.ExerciseId, exerciseEntry);
                    }

                    if (question != null)
                    {
                        if (exerciseEntry.Questions == null)
                            exerciseEntry.Questions = new List<GetQuestionDto>();

                        if (!exerciseEntry.Questions.Any(q => q.QuestionId == question.QuestionId))
                        {
                            exerciseEntry.Questions.Add(question);
                            question.Answers = new List<GetAnswerDto>();
                        }
                    }

                    if (answer != null)
                    {
                        var currentQuestion = exerciseEntry.Questions.SingleOrDefault(q => q.QuestionId == answer.QuestionId);
                        if (currentQuestion != null)
                            currentQuestion.Answers.Add(answer);
                    }

                    return exerciseEntry;
                },
                dynamicParams,
                splitOn: "QuestionId, AnswerId",
                commandType: CommandType.StoredProcedure
            );

            return lookup.Values.FirstOrDefault();
        }
    }
}

