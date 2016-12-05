using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTestingProject
{
   public class ResultExam
    {
        [Key]
        public int ResultId { get; set; }
        public int Result { get; set; }
        public string NameExam { get; set; }
        public int UserId { get; set; }
        public virtual User user { get; set; }
    }
    public static class ResultExamp
    {
       public static int GetResult(string NameExam,string loginUser)
        {
            Connect db = new Connect();
            int a = 0;
            foreach (var item in db.Users.ToList())
            {
                if (item.Username == loginUser)
                {
                    foreach (var item1 in item.Result)
                    {
                        if (item1.NameExam == NameExam)
                        {
                            if (item1.Result > a)
                                a = item1.Result;
                        }
                    }
                }
            }
            return a;
        }
        public static void SetExampResult(string NameExam,string loginUser,int Result)
        {
            Connect db = new Connect();
            foreach (var item in db.Users.ToList())
            {
                if (item.Username == loginUser)
                {
                    db.Users.Single((x) => x.Username == loginUser).Result.Add(new ResultExam() { NameExam = NameExam, Result = Result, user = item });
                }
            }
            db.SaveChanges();
        }
      
    }
    

    
}
