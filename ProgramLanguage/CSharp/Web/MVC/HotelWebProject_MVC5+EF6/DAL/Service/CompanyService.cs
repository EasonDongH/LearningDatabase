using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class CompanyService
    {
        public List<Suggestion> GetSuggestionsList()
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from s in hotelDBEntities.Suggestion select s).ToList();
            }
        }

        public int AddSuggestion(Suggestion suggestion)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                hotelDBEntities.Entry<Suggestion>(suggestion).State = System.Data.Entity.EntityState.Added;
                return hotelDBEntities.SaveChanges();
            }
        }

        public int DeleteSuggestionById(int suggestionId)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                Suggestion suggestion = new Suggestion { SuggestionId = suggestionId };
                hotelDBEntities.Entry<Suggestion>(suggestion).State = System.Data.Entity.EntityState.Deleted;
                return hotelDBEntities.SaveChanges();
            }
        }

        public int AddRecruitment(Recruitment recruitment)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                hotelDBEntities.Entry<Recruitment>(recruitment).State = System.Data.Entity.EntityState.Added;
                return hotelDBEntities.SaveChanges();
            }
        }

        public List<Recruitment> GetRecruitmentList()
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from r in hotelDBEntities.Recruitment orderby r.PublishTime select r).ToList();
            }
        }

        public Recruitment GetRecruitmentById(int postId)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from r in hotelDBEntities.Recruitment where r.PostId==postId select r).FirstOrDefault();
            }
        }

        public int DeleteRecruitmentById(int postId)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                Recruitment recruitment = new Recruitment { PostId = postId };
                hotelDBEntities.Entry<Recruitment>(recruitment).State = System.Data.Entity.EntityState.Deleted;
                return hotelDBEntities.SaveChanges();
            }
        }

        public int ModifyRecruitment(Recruitment recruitment)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                hotelDBEntities.Entry<Recruitment>(recruitment).State = System.Data.Entity.EntityState.Modified;
                return hotelDBEntities.SaveChanges();
            }
        }
    }
}
