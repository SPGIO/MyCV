using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCV.Models;

namespace MyCVTest
{
    [TestClass]
    public class PersonalInformationTest
    {
        [TestMethod]
        public void FullName()
        {
            var personalInformation = new PersonalInformation();
            personalInformation.FirstName = "Simon";
            personalInformation.LastName = "Svensson";
            Assert.IsTrue(personalInformation.FullName == "Simon Svensson");

            personalInformation.MiddleName = "Gyldendal";

            Assert.IsTrue(personalInformation.FullName == "Simon Gyldendal Svensson");
        }


    }

    [TestClass]
    public class ExperienceTest
    {



        [TestMethod]
        [ExpectedException(typeof(DateTimeTooSmallException))]
        public void EndDateBeginsBeforeStartDate()
        {

            var work = new WorkExperience("Software Developer",
                                      "Gained a lot of experience",
                                      "IT-Minds",
                                      new System.DateTime(2020, 03, 03),
                                      new System.DateTime(2020, 03, 02));
        }

        [TestMethod]
        public void EndDateAndStartDateHasValidDates()
        {
            var work = new WorkExperience("Software Developer",
                                      "Gained a lot of experience",
                                      "IT-Minds",
                                      new System.DateTime(2020, 03, 03),
                                      new System.DateTime(2020, 03, 03));
            Assert.IsTrue(work.StartDate <= work.EndDate);
        }

        [TestMethod]
        public void PrintableDatesSameDate()
        {
            var work = new WorkExperience("Software Developer",
                                      "Gained a lot of experience",
                                      "IT-Minds",
                                      new System.DateTime(2020, 03, 03),
                                      new System.DateTime(2020, 03, 03));

            Assert.IsTrue(work.FullDate == "2020");
        }


        [TestMethod]
        public void PrintableDateDifferentDate()
        {
            var work = new WorkExperience("Software Developer",
                                      "Gained a lot of experience",
                                      "IT-Minds",
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
            cv.ShortResume =  "this is cool";
            Assert.IsTrue(cv.ShortResumeWithThreeDots(4) == "this...");
            Assert.IsTrue(cv.ShortResumeWithThreeDots(5) == "this ...");
            Assert.IsTrue(cv.ShortResumeWithThreeDots(6) == "this i...");
            Assert.IsTrue(cv.ShortResumeWithThreeDots(7) == "this is...");
            Assert.IsTrue(cv.ShortResumeWithThreeDots(13) == "this is cool");

        }
    }
}
