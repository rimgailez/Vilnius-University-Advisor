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

        public void Add(T entity)
        {
            entitiesList.Add(entity);
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
            List<T> filteredEntities = (from ent in entitiesList
                                          where ent.faculty == faculty
                                          select ent).ToList();
            return filteredEntities;
        }

        public void EvaluateEntity(T entity, float subjectScore, Review review)
        {
            float sum = entity.score * entity.numberOfReviews;
            entity.numberOfReviews++;
            entity.score = (sum + subjectScore) / entity.numberOfReviews;
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
