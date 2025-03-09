using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("There are less than 5 students.Need more");
            }

            int N = (int)(Students.Count*0.2);
            int M = 0;
            for (int i = 0; i < Students.Count; i++)
            {
                if (averageGrade < Students[i].AverageGrade) { M++; };
            }
            int rank = M / N;
            switch (rank) 
            {
                case 0:
                    return 'A';
                case 1:
                    return 'B';
                case 2:
                    return 'C';
                case 3:
                    return 'D';
                default:
                    return 'F';
            }

        }
    }
}
