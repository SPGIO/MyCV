using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCV.Models;
using MyCV.Models.Criteria;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyCVTest
{
    [TestClass]
    public class PersonalInformationTest
    {
        [TestMethod]
        public void FullName()
        {
            var personalInformation = new PersonalInformation();
            personalInformation.FirstName = "Joe";
            personalInformation.LastName = "Joejoe";
            Assert.IsTrue(personalInformation.FullName == "Joe Joejoe");

            personalInformation.MiddleName = "Test";

            Assert.IsTrue(personalInformation.FullName == "Joe Test Joejoe");
        }
    }

    [TestClass]
    public class ExperienceTest
    {
        [TestMethod]
        [ExpectedException(typeof(DateTimeTooSmallException))]
        public void EndDateBeginsBeforeStartDate()
        {

            var work = new Experience("Software Developer",
                                      "Software Company",
                                      new System.DateTime(2020, 03, 03),
                                      new System.DateTime(2020, 03, 02));
        }

        [TestMethod]
        public void EndDateAndStartDateHasValidDates()
        {
            var work = new Experience("Software Developer",
                                      "Software Company",
                                      new System.DateTime(2020, 03, 03),
                                      new System.DateTime(2020, 03, 03));
            Assert.IsTrue(work.StartDate <= work.EndDate);
        }

        [TestMethod]
        public void PrintableDatesSameDate()
        {
            var work = new Experience("Software Developer",
                                      "Software Company",
                                      new System.DateTime(2020, 03, 03),
                                      new System.DateTime(2020, 03, 03));

            Assert.IsTrue(work.FullDate == "2020");
        }


        [TestMethod]
        public void PrintableDateDifferentDate()
        {
            var work = new Experience("Software Developer",
                                      "Software Company",
                                      new System.DateTime(2017, 03, 03),
                                      new System.DateTime(2020, 03, 03));

            Assert.IsTrue(work.FullDate == "2017 - 2020");
        }
    }

    [TestClass]
    public class CVTest
    {
        [TestMethod]
        public void ShortResumeWithThreeDots()
        {
            var cv = new CurriculumVitae();
            cv.ShortResume = "this is cool";
            Assert.IsTrue(cv.ShortResumeWithThreeDots(4) == "this...");
            Assert.IsTrue(cv.ShortResumeWithThreeDots(5) == "this ...");
            Assert.IsTrue(cv.ShortResumeWithThreeDots(6) == "this i...");
            Assert.IsTrue(cv.ShortResumeWithThreeDots(7) == "this is...");
            Assert.IsTrue(cv.ShortResumeWithThreeDots(13) == "this is cool");

        }
    }

    [TestClass]
    public class CriteriaTest
    {
        [TestMethod]
        public void OrderByEndDateWorksWithEmptyList()
        {
            ICollection<Experience> emptyList = new List<Experience>();
            var OrderCriteria = new OrderByEndDateCriteria();
            var actual = OrderCriteria.MeetCriteria(emptyList);
            ICollection<Experience> expected = new List<Experience>();
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void OrderByEndDateListUnOrderedList()
        {
            ICollection<Experience> unorderedList = new List<Experience>();
            var experience1 = new Experience("test",
                                            "test",
                                             new System.DateTime(2020,01,01),
                                             new System.DateTime(2020,02,01));
            var experience2 = new Experience("test",
                                            "test",
                                             new System.DateTime(2019,01,01),
                                             new System.DateTime(2019,02,01));

            unorderedList.Add(experience2);
            unorderedList.Add(experience1);
            var OrderCriteria = new OrderByEndDateCriteria();
            var actual = OrderCriteria.MeetCriteria(unorderedList);
            ICollection<Experience> expected = new List<Experience>();
            expected.Add(experience1);
            expected.Add(experience2);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void OrderByEndDateListOrderedList()
        {
            ICollection<Experience> unorderedList = new List<Experience>();
            var experience1 = new Experience("test",
                                            "test",
                                             new System.DateTime(2020,01,01),
                                             new System.DateTime(2020,02,01));
            var experience2 = new Experience("test",
                                            "test",
                                             new System.DateTime(2019,01,01),
                                             new System.DateTime(2019,02,01));

            unorderedList.Add(experience1);
            unorderedList.Add(experience2);
            var OrderCriteria = new OrderByEndDateCriteria();
            var actual = OrderCriteria.MeetCriteria(unorderedList);
            ICollection<Experience> expected = new List<Experience>();
            expected.Add(experience1);
            expected.Add(experience2);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void OrderByEndDateListIsNull()
        {
            var OrderCriteria = new OrderByEndDateCriteria();
            var actual = OrderCriteria.MeetCriteria(null);
            ICollection<Experience> expected = new List<Experience>();
            Assert.IsTrue(expected.SequenceEqual(actual));
        }



        [TestMethod]
        public void EducationCriteriaWorksWithEmptyList()
        {
            ICollection<Experience> emptyList = new List<Experience>();
            var educationCriteria = new EducationCriteria();
            var actual = educationCriteria.MeetCriteria(emptyList);
            ICollection<Experience> expected = new List<Experience>();
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void EducationCriteriaNull()
        {
            var educationCriteria = new EducationCriteria();
            var actual = educationCriteria.MeetCriteria(null);
            ICollection<Experience> expected = new List<Experience>();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void EducationCriteriaWorksWithOneItemNotEducation()
        {
            ICollection<Experience> listWithOneItem = new List<Experience>();
            var educationExperience = new Experience("test",
                                                     "test",
                                                     new System.DateTime(),
                                                     new System.DateTime());
            educationExperience.Category = new ExperienceCategory();
            educationExperience.Category.Category = "anything other than Uddannelse";
            listWithOneItem.Add(educationExperience);

            var educationCriteria = new EducationCriteria();
            var actual = educationCriteria.MeetCriteria(listWithOneItem);
            ICollection<Experience> expected = new List<Experience>();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void EducationCriteriaWorksWithOneItemEducation()
        {
            ICollection<Experience> listWithOneItem = new List<Experience>();
            var educationExperience = new Experience("test",
                                                     "test",
                                                     new System.DateTime(),
                                                     new System.DateTime());
            educationExperience.Category = new ExperienceCategory();
            educationExperience.Category.Category = "Uddannelse";
            listWithOneItem.Add(educationExperience);

            var educationCriteria = new EducationCriteria();
            var actual = educationCriteria.MeetCriteria(listWithOneItem);
            ICollection<Experience> expected = new List<Experience>();
            expected.Add(educationExperience);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}

