using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class UniversityEntitiesList<T> : IEnumerable<T>
        where T : DataNode
    {
        private static readonly UniversityEntitiesList<T> entityInstance = new UniversityEntitiesList<T>();

        private List<T> entitiesList;

        public UniversityEntitiesList()
        {
            entitiesList = new List<T>();
        }

        public T GetEntity(int index)
        {
            return entitiesList[index];
        }

        public List<T> GetListOfUniversityEntities()
        {
            return entitiesList;
        }

        public void SetListOfUniversityEntities(List<T> newEntitiesList)
        {
            entitiesList = newEntitiesList;
        }

        public void Add(T entity)
        {
            entitiesList.Add(entity);
        }

        public static UniversityEntitiesList<T> GetEntityInstance()
        {
            return entityInstance;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return entitiesList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entitiesList.GetEnumerator();
        }

        public List<T> GetEntitySearchResults(String enteredWord, Faculty faculty, UniversityEntitiesList<T> entList)
        {
            List<T> searchResult = (from ent in entList.entitiesList
                                          where ent.name.ToLower().Contains(enteredWord.ToLower()) && ent.faculty == faculty
                                          select ent).ToList();
            return searchResult;
        }

        public List<T> GetEntitiesByFaculty(Faculty faculty, UniversityEntitiesList<T> entList)
        {
            List<T> filteredEntities = (from ent in entList.entitiesList
                                          where ent.faculty == faculty
                                          select ent).ToList();
            return filteredEntities;
        }

        public void EvaluateEntity(T entity, float subjectScore, string review, UniversityEntitiesList<T> entList)
        {
            T tempEntity = entList.entitiesList.Find(ent => ent.Equals(entity));
            float sum = tempEntity.score * tempEntity.numberOfReviews;
            tempEntity.numberOfReviews++;
            tempEntity.score = (sum + subjectScore) / tempEntity.numberOfReviews;
            tempEntity.reviews.Add(review);
            entList.entitiesList[entList.entitiesList.FindIndex(ent => ent.Equals(entity))] = tempEntity;
            DataMaster.GetInstance().WriteData();
        }

        public void AddEntityWithoutWriting(T entity, UniversityEntitiesList<T> entList)
        {
            if (!entList.entitiesList.Contains(entity)) entList.entitiesList.Add(entity);
        }

        public void SortList(UniversityEntitiesList<T> entList)
        {
            entList.entitiesList.Sort();
        }

    }
}
