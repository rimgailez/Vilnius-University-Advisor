using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUA_api
{
    public class UniversityEntitiesList<T> : IEnumerable<T>
        where T : DataNode
    {
        private List<T> entitiesList;

        public UniversityEntitiesList()
        {
            entitiesList = new List<T>();
        }
        public T this[int i]
        {
            get { return entitiesList[i]; }
            set { entitiesList[i] = value; }
        }

        public List<T> GetListOfUniversityEntities()
        {
            return entitiesList;
        }

        public void SetListOfUniversityEntities(List<T> newEntitiesList)
        {
            entitiesList = newEntitiesList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return entitiesList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entitiesList.GetEnumerator();
        }

        public List<T> GetEntitySearchResults(String enteredWord, Faculty faculty)
        {
            List<T> searchResult = (from ent in entitiesList
                                          where ent.name.ToLower().Contains(enteredWord.ToLower()) && ent.faculty == faculty
                                          select ent).ToList();
            return searchResult;
        }

        public List<T> GetEntitiesByFaculty(Faculty faculty)
        {
            return entitiesList.Where(ent => ent.faculty == faculty).ToList();
        }

        public void EvaluateEntity(T entity, float subjectScore, Review review)
        {
            Func<T, float, float> calculateScore = delegate (T entityNew, float newScore)
             {
                 return ((entityNew.score * entityNew.numberOfReviews) + newScore)/(++entity.numberOfReviews);
             };
            entity.score = calculateScore(entity, subjectScore);
            entity.reviews.Add(review);
            DataMaster.GetInstance().WriteData();
        }

        public void AddEntityWithoutWriting(T entity)
        {
            if (!entitiesList.Contains(entity)) entitiesList.Add(entity);
        }

        public void Sort()
        {
            entitiesList.Sort();
        }

    }
}
