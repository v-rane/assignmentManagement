using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AssignmentManagement
{
    public class AssignmentOperations
    {
        /*
         * @className - AssignmentOperations
         * @objective -aggregate data and display student data accordingly
         * @autherName - Varsha Rane
         * @date - 20-4-2022
         */
        public List<AssignmentByStatusAndTime> getAssignmentByCourseTime(List<StudentData> studentDataList)
        {
            /*
             * @methodName - getAssignmentByCourseTime
             * @objective - to display assignment by course and time
             * @para -List<StudentData>
             * @return - List<AssignmentByStatusAndTime>
             */

            Dictionary<int, AssignmentByStatusAndTime> key = new Dictionary<int, AssignmentByStatusAndTime>();
            //dictionary is created with id as key and AssignmentByStatusAndTime object as values
            List<AssignmentByStatusAndTime> assignmentList = new List<AssignmentByStatusAndTime>();
            foreach (StudentData data in studentDataList)
            {
                if (key.ContainsKey(data.StudentId))
                {
                    //if status is complete then increment in timeTaken and completed studentId
                    if (data.Status == "Completed")
                    {
                        key[data.StudentId].NumOfCouseCompleted++;
                        key[data.StudentId].TimeTaken += data.Duration;
                    }
                }
                else
                {
                    //if status is completed then add values in AssignmentByStatusAndTime to the respective id by creating object of it
                    if (data.Status == "Completed")
                    {
                        key.Add(data.StudentId, new AssignmentByStatusAndTime());
                        key[data.StudentId].studentId = data.StudentId;
                        key[data.StudentId].StudentName = data.StudentName;
                        key[data.StudentId].NumOfCouseCompleted = 1;
                        key[data.StudentId].TimeTaken = data.Duration;
                    }
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            foreach (AssignmentByStatusAndTime data in key.Values)
            {
                assignmentList.Add(data);
            }
            //return key.Values.ToList();
            return assignmentList;
        }
        //********************************************************************************************************************************
        public List<AssignByCourseAndStatus> getDataByCourseAndStudent(List<StudentData> list)
        {
            /*
             * @methodName - getDataByCourseAndStudent
             * @objective - to display assignment by course and student
             * @para - List<StudentData> 
             * @return -List<AssignByCourseAndStatus>
             */

            //dic is created with subject as key and AssignByCourseAndStatus as value
            Dictionary<string, AssignByCourseAndStatus> assignDic = new Dictionary<string, AssignByCourseAndStatus>();
            //for storing result
            List<AssignByCourseAndStatus> resList  = new List<AssignByCourseAndStatus>();
            //iterating list and check if dic contains subject then check if status is complete so increment in NumOfStudentsCompleted otherwise increment in progress 
            foreach (StudentData data in list)
            {
                if (assignDic.ContainsKey(data.Subject))
                {
                    if(data.Status== "Completed")
                    {
                        assignDic[data.Subject].NumOfStudentsCompleted++;
                    }
                    else
                    {
                        assignDic[data.Subject].NumOfStudentsInProgress++;
                    }
                }
                //if dic does not contains key then check status is complete and add new object for that subject and assign values to it
                else
                {
                    if (data.Status == "Completed")
                    {
                        assignDic[data.Subject] = new AssignByCourseAndStatus();
                        assignDic[data.Subject].subject = data.Subject;
                        assignDic[data.Subject].NumOfStudentsCompleted = 1;
                        assignDic[data.Subject].NumOfStudentsInProgress = 0;
                    }
                    else
                    {
                        //for not completed 
                        assignDic.Add(data.Subject, new AssignByCourseAndStatus());
                        assignDic[data.Subject].subject = data.Subject;
                        assignDic[data.Subject].NumOfStudentsInProgress = 1;
                        assignDic[data.Subject].NumOfStudentsCompleted= 0;
                    }
                }
            }
            //add values of dic to list
            foreach(AssignByCourseAndStatus data in assignDic.Values)
            {
                resList.Add(data);
            }
            //returning list
            return resList;
        }

    }
}
