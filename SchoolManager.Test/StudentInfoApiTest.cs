using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Common.StudentInfoVMs;
using SchoolManager.Model.Business;
using SchoolManager.DataAccess;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.Test
{
    [TestClass]
    public class StudentInfoApiTest
    {
        private StudentInfoController _controller;
        private string _seed;

        public StudentInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<StudentInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new StudentInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            StudentInfoVM vm = _controller.Wtm.CreateVM<StudentInfoVM>();
            StudentInfo v = new StudentInfo();
            
            v.ID = 97;
            v.Code = "lK6DLi";
            v.Name = "9NPwc";
            v.CellPhone = "dMC2o1oD2";
            v.ZipCode = "Wjntc4";
            v.EmContacts = "Jvy3jjC";
            v.EmConPhone = "7FC9poO7e";
            v.SchoolInfoId = AddSchoolInfo();
            v.MajorInfoId = AddMajorInfo();
            v.PhotoId = AddPhoto();
            v.GradeClassId = AddGradeClass();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StudentInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 97);
                Assert.AreEqual(data.Code, "lK6DLi");
                Assert.AreEqual(data.Name, "9NPwc");
                Assert.AreEqual(data.CellPhone, "dMC2o1oD2");
                Assert.AreEqual(data.ZipCode, "Wjntc4");
                Assert.AreEqual(data.EmContacts, "Jvy3jjC");
                Assert.AreEqual(data.EmConPhone, "7FC9poO7e");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            StudentInfo v = new StudentInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 97;
                v.Code = "lK6DLi";
                v.Name = "9NPwc";
                v.CellPhone = "dMC2o1oD2";
                v.ZipCode = "Wjntc4";
                v.EmContacts = "Jvy3jjC";
                v.EmConPhone = "7FC9poO7e";
                v.SchoolInfoId = AddSchoolInfo();
                v.MajorInfoId = AddMajorInfo();
                v.PhotoId = AddPhoto();
                v.GradeClassId = AddGradeClass();
                context.Set<StudentInfo>().Add(v);
                context.SaveChanges();
            }

            StudentInfoVM vm = _controller.Wtm.CreateVM<StudentInfoVM>();
            var oldID = v.ID;
            v = new StudentInfo();
            v.ID = oldID;
       		
            v.Code = "jhjph";
            v.Name = "BezCb";
            v.CellPhone = "q8ksam";
            v.ZipCode = "O5kEW";
            v.EmContacts = "nSgp7";
            v.EmConPhone = "fcYUZiDK";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.CellPhone", "");
            vm.FC.Add("Entity.ZipCode", "");
            vm.FC.Add("Entity.EmContacts", "");
            vm.FC.Add("Entity.EmConPhone", "");
            vm.FC.Add("Entity.SchoolInfoId", "");
            vm.FC.Add("Entity.MajorInfoId", "");
            vm.FC.Add("Entity.PhotoId", "");
            vm.FC.Add("Entity.GradeClassId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StudentInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "jhjph");
                Assert.AreEqual(data.Name, "BezCb");
                Assert.AreEqual(data.CellPhone, "q8ksam");
                Assert.AreEqual(data.ZipCode, "O5kEW");
                Assert.AreEqual(data.EmContacts, "nSgp7");
                Assert.AreEqual(data.EmConPhone, "fcYUZiDK");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            StudentInfo v = new StudentInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 97;
                v.Code = "lK6DLi";
                v.Name = "9NPwc";
                v.CellPhone = "dMC2o1oD2";
                v.ZipCode = "Wjntc4";
                v.EmContacts = "Jvy3jjC";
                v.EmConPhone = "7FC9poO7e";
                v.SchoolInfoId = AddSchoolInfo();
                v.MajorInfoId = AddMajorInfo();
                v.PhotoId = AddPhoto();
                v.GradeClassId = AddGradeClass();
                context.Set<StudentInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            StudentInfo v1 = new StudentInfo();
            StudentInfo v2 = new StudentInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 97;
                v1.Code = "lK6DLi";
                v1.Name = "9NPwc";
                v1.CellPhone = "dMC2o1oD2";
                v1.ZipCode = "Wjntc4";
                v1.EmContacts = "Jvy3jjC";
                v1.EmConPhone = "7FC9poO7e";
                v1.SchoolInfoId = AddSchoolInfo();
                v1.MajorInfoId = AddMajorInfo();
                v1.PhotoId = AddPhoto();
                v1.GradeClassId = AddGradeClass();
                v2.ID = 54;
                v2.Code = "jhjph";
                v2.Name = "BezCb";
                v2.CellPhone = "q8ksam";
                v2.ZipCode = "O5kEW";
                v2.EmContacts = "nSgp7";
                v2.EmConPhone = "fcYUZiDK";
                v2.SchoolInfoId = v1.SchoolInfoId; 
                v2.MajorInfoId = v1.MajorInfoId; 
                v2.PhotoId = v1.PhotoId; 
                v2.GradeClassId = v1.GradeClassId; 
                context.Set<StudentInfo>().Add(v1);
                context.Set<StudentInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<StudentInfo>().Find(v1.ID);
                var data2 = context.Set<StudentInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Int32 AddSchoolInfo()
        {
            SchoolInfo v = new SchoolInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 75;
                v.Code = "nTRX";
                v.Name = "E1DeNB";
                v.EnglishName = "RunNvxQ";
                v.PinyinName = "77a";
                v.SimplePinyinName = "IUvzv4N";
                v.SimpleName = "7ztAH8H";
                v.Contacts = "1aK";
                v.Phone = "DWNT9EsX";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.CDJY;
                v.Address = "1ggSgGISm";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.XZXQ;
                context.Set<SchoolInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddMajorInfo()
        {
            MajorInfo v = new MajorInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 95;
                v.Code = "CSiT";
                v.Name = "b2SGAGBlh";
                context.Set<MajorInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddPhoto()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.FileName = "LQdqi2G";
                v.FileExt = "BKHY";
                v.Path = "TytQ9";
                v.Length = 94;
                v.SaveMode = "RRF4H9Z";
                v.ExtraInfo = "2DRw44V";
                v.HandlerInfo = "RZ1mPv";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddGrade()
        {
            GradeInfo v = new GradeInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 50;
                v.Code = "0D10D";
                v.Name = "DSHxhO";
                context.Set<GradeInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddGradeClass()
        {
            GradeClassInfo v = new GradeClassInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 8;
                v.Code = "SXh6Cq1MT";
                v.GradeId = AddGrade();
                v.Name = "jLh";
                context.Set<GradeClassInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
