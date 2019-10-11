using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class UniversityEntity<T>
    {
        private static readonly UniversityEntity<T> entityInstance = new UniversityEntity<T>();

        public static UniversityEntity<T> GetEntityInstance()
        {
            return entityInstance;
        }

        public void EvaluateUniversityEntity(T entity, float score, string review, ref List<T> entitiesList, List<string> listOfReviews)
        {
            T tempEntity = entitiesList.Find(ent => ent.Equals(entity));
            var previousScore = typeof(T).GetProperty("score").GetValue(tempEntity);
            var previousNoOfReviews = typeof(T).GetProperty("numberOfReviews").GetValue(tempEntity);
            var sum = (float)previousScore * (int)previousNoOfReviews;
            var noOfReviews = (int)previousNoOfReviews + 1;
            typeof(T).GetProperty("numberOfReviews").SetValue(tempEntity, noOfReviews);
            typeof(T).GetProperty("score").SetValue(tempEntity, (float) (sum + score) / noOfReviews);
            listOfReviews.Add(review);
            entitiesList[entitiesList.FindIndex(ent => ent.Equals(entity))] = tempEntity;
            DataMaster.GetInstance().WriteData();
        }

        public List<T> GetEntitySearchResults(String enteredWord, Faculty faculty, List<T> entitiesList)
        {
            
            List <T> searchResult = (from entity in entitiesList
                                        where typeof(T).GetProperty("name").GetValue(entity).ToString().ToLower().Contains(enteredWord.ToLower()) && typeof(T).GetProperty("faculty").GetValue(entity).Equals(faculty)
                                        select entity).ToList();
            return searchResult;
        }

        public void AddEntityWithoutWriting(T entity, ref List<T> entitiesList)
        {
            if (!entitiesList.Contains(entity)) entitiesList.Add(entity);
        }

        public void AddEntity(T entity, ref List<T> entitiesList)
        {
            AddEntityWithoutWriting(entity, ref entitiesList);
            entitiesList = entitiesList.OrderBy(ent => typeof(T).GetProperty("name").GetValue(ent)).ToList();
            DataMaster.GetInstance().WriteData();
        }

        public List<T> GetEntitiesByFaculty(Faculty faculty, List<T> entitiesList)
        {
            List<T> filteredEntities = (from entity in entitiesList
                                        where typeof(T).GetProperty("faculty").GetValue(entity).Equals(faculty)
                                        select entity).ToList();
            return filteredEntities;
        }


    }
}
