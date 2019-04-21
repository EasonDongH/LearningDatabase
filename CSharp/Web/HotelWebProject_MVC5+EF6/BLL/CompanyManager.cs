using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class CompanyManager
    {
        private CompanyService objCompanyService = new CompanyService();

        public List<Suggestion> GetSuggestionsList()
        {
            return objCompanyService.GetSuggestionsList();
        }

        public int AddSuggestion(Suggestion suggestion)
        {
            suggestion.StatusId = 0;
            return objCompanyService.AddSuggestion(suggestion);
        }

        public int DeleteSuggestionById(int suggestionId)
        {
            return objCompanyService.DeleteSuggestionById(suggestionId);
        }

        public List<Recruitment> GetRecruitmentList()
        {
            return objCompanyService.GetRecruitmentList();
        }

        public Recruitment GetRecruitmentById(int postId)
        {
            return objCompanyService.GetRecruitmentById(postId);
        }

        public int AddRecruitment(Recruitment recruitment)
        {
            return objCompanyService.AddRecruitment(recruitment);
        }

        public int DeleteRecruitmentById(int postId)
        {
            return objCompanyService.DeleteRecruitmentById(postId);
        }

        public int ModifyRecruitment(Recruitment recruitment)
        {
            return objCompanyService.ModifyRecruitment(recruitment);
        }
    }
}
