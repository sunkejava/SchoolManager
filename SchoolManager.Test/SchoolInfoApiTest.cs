using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.SchoolInfoVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class SchoolInfoApiTest
    {
        private SchoolInfoController _controller;
        private string _seed;

        public SchoolInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<SchoolInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new SchoolInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            SchoolInfoVM vm = _controller.Wtm.CreateVM<SchoolInfoVM>();
            SchoolInfo v = new SchoolInfo();
            
            v.ID = 79;
            v.Code = "hKt";
            v.Name = "hElacNXg";
            v.EnglishName = "k1b";
            v.PinyinName = "SisFz37Ec";
            v.SimplePinyinName = "zzB2vl";
            v.SimpleName = "s6klLEy";
            v.Contacts = "d9VT";
            v.Phone = "bn15";
            v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.CDJY;
            v.Address = "BVMW";
            v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.XZXQ;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SchoolInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 79);
                Assert.AreEqual(data.Code, "hKt");
                Assert.AreEqual(data.Name, "hElacNXg");
                Assert.AreEqual(data.EnglishName, "k1b");
                Assert.AreEqual(data.PinyinName, "SisFz37Ec");
                Assert.AreEqual(data.SimplePinyinName, "zzB2vl");
                Assert.AreEqual(data.SimpleName, "s6klLEy");
                Assert.AreEqual(data.Contacts, "d9VT");
                Assert.AreEqual(data.Phone, "bn15");
                Assert.AreEqual(data.TypeOfEducation, SchoolManager.Model.BasicInfo.TypeOfEducationEnum.CDJY);
                Assert.AreEqual(data.Address, "BVMW");
                Assert.AreEqual(data.TypeOfUrbanAndRural, SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.XZXQ);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            SchoolInfo v = new SchoolInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 79;
                v.Code = "hKt";
                v.Name = "hElacNXg";
                v.EnglishName = "k1b";
                v.PinyinName = "SisFz37Ec";
                v.SimplePinyinName = "zzB2vl";
                v.SimpleName = "s6klLEy";
                v.Contacts = "d9VT";
                v.Phone = "bn15";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.CDJY;
                v.Address = "BVMW";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.XZXQ;
                context.Set<SchoolInfo>().Add(v);
                context.SaveChanges();
            }

            SchoolInfoVM vm = _controller.Wtm.CreateVM<SchoolInfoVM>();
            var oldID = v.ID;
            v = new SchoolInfo();
            v.ID = oldID;
       		
            v.Code = "JrZwTIqa";
            v.Name = "pyKYAk3T";
            v.EnglishName = "MGzLN";
            v.PinyinName = "RcxXTgDP2";
            v.SimplePinyinName = "5ItGpEmXn";
            v.SimpleName = "VUEsBmdK";
            v.Contacts = "DR4q";
            v.Phone = "DMb0";
            v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.XQJY;
            v.Address = "mcO6Q";
            v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.CXJHQ;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.EnglishName", "");
            vm.FC.Add("Entity.PinyinName", "");
            vm.FC.Add("Entity.SimplePinyinName", "");
            vm.FC.Add("Entity.SimpleName", "");
            vm.FC.Add("Entity.Contacts", "");
            vm.FC.Add("Entity.Phone", "");
            vm.FC.Add("Entity.TypeOfEducation", "");
            vm.FC.Add("Entity.Address", "");
            vm.FC.Add("Entity.TypeOfUrbanAndRural", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SchoolInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "JrZwTIqa");
                Assert.AreEqual(data.Name, "pyKYAk3T");
                Assert.AreEqual(data.EnglishName, "MGzLN");
                Assert.AreEqual(data.PinyinName, "RcxXTgDP2");
                Assert.AreEqual(data.SimplePinyinName, "5ItGpEmXn");
                Assert.AreEqual(data.SimpleName, "VUEsBmdK");
                Assert.AreEqual(data.Contacts, "DR4q");
                Assert.AreEqual(data.Phone, "DMb0");
                Assert.AreEqual(data.TypeOfEducation, SchoolManager.Model.BasicInfo.TypeOfEducationEnum.XQJY);
                Assert.AreEqual(data.Address, "mcO6Q");
                Assert.AreEqual(data.TypeOfUrbanAndRural, SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.CXJHQ);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            SchoolInfo v = new SchoolInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 79;
                v.Code = "hKt";
                v.Name = "hElacNXg";
                v.EnglishName = "k1b";
                v.PinyinName = "SisFz37Ec";
                v.SimplePinyinName = "zzB2vl";
                v.SimpleName = "s6klLEy";
                v.Contacts = "d9VT";
                v.Phone = "bn15";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.CDJY;
                v.Address = "BVMW";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.XZXQ;
                context.Set<SchoolInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            SchoolInfo v1 = new SchoolInfo();
            SchoolInfo v2 = new SchoolInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 79;
                v1.Code = "hKt";
                v1.Name = "hElacNXg";
                v1.EnglishName = "k1b";
                v1.PinyinName = "SisFz37Ec";
                v1.SimplePinyinName = "zzB2vl";
                v1.SimpleName = "s6klLEy";
                v1.Contacts = "d9VT";
                v1.Phone = "bn15";
                v1.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.CDJY;
                v1.Address = "BVMW";
                v1.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.XZXQ;
                v2.ID = 19;
                v2.Code = "JrZwTIqa";
                v2.Name = "pyKYAk3T";
                v2.EnglishName = "MGzLN";
                v2.PinyinName = "RcxXTgDP2";
                v2.SimplePinyinName = "5ItGpEmXn";
                v2.SimpleName = "VUEsBmdK";
                v2.Contacts = "DR4q";
                v2.Phone = "DMb0";
                v2.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.XQJY;
                v2.Address = "mcO6Q";
                v2.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.CXJHQ;
                context.Set<SchoolInfo>().Add(v1);
                context.Set<SchoolInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SchoolInfo>().Find(v1.ID);
                var data2 = context.Set<SchoolInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
