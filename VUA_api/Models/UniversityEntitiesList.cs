using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUA_api;

namespace VUA_api
{
    public class UniversityEntitiesList<T> : IEnumerable<T>
        where T : DataNode
    {
        private DbSet<T> entitiesList;

        public UniversityEntitiesList(DbSet<T> entitiesList)
        {
            this.entitiesList = entitiesList;
        }
        //public T this[int i]
        //{
        //    get { return entitiesList[i]; }
        //    set { entitiesList[i] = value; }
        //}

        public List<T> GetListOfUniversityEntities()
        {
            return entitiesList.ToList();
        }

        //public void SetListOfUniversityEntities(List<T> newEntitiesList)
        //{
        //    entitiesList = newEntitiesList;
        //}

        public IEnumerator<T> GetEnumerator()
        {
            return entitiesList.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entitiesList.ToList().GetEnumerator();
        }

        public List<T> GetEntitySearchResults(String enteredWord, Faculty faculty)
        {
            List<T> searchResult;
            if (faculty == Faculty.None)
            {
                searchResult = (from ent in entitiesList
                                where ent.name.ToLower().Contains(enteredWord.ToLower())
                                select ent).ToList();
            }
            else
            {
                searchResult = (from ent in entitiesList
                                where ent.name.ToLower().Contains(enteredWord.ToLower()) && ent.faculty == faculty
                                select ent).ToList();
            }
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

            if (entity.GetType() == typeof(Lecturer))
            {
                Lecturer entityNew = entity as Lecturer;
                entityNew.reviews.Add(review as LecturerReview);
            }
            if (entity.GetType() == typeof(Subject))
            {
                Subject entityNew = entity as Subject;
                entityNew.reviews.Add(review as SubjectReview);
            }
        }

        public void AddEntityWithoutWriting(T entity)
        {
            if (!entitiesList.Contains(entity)) entitiesList.Add(entity);
        }

        public List<T> GetTopEntities()
        {
            return entitiesList.OrderByDescending(ent => ent.score).ToList();
        }

    }
}
