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
            
            v.ID = 59;
            v.Code = "y79oUK1sV";
            v.Name = "iACTwL8C8";
            v.EnglishName = "o77oL";
            v.PinyinName = "XGLn";
            v.SimplePinyinName = "jnRddCcIV";
            v.SimpleName = "Ji8zAsg";
            v.Contacts = "JOO";
            v.Phone = "zJdd";
            v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.XQJY;
            v.Address = "5C1HL";
            v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZCQ;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SchoolInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 59);
                Assert.AreEqual(data.Code, "y79oUK1sV");
                Assert.AreEqual(data.Name, "iACTwL8C8");
                Assert.AreEqual(data.EnglishName, "o77oL");
                Assert.AreEqual(data.PinyinName, "XGLn");
                Assert.AreEqual(data.SimplePinyinName, "jnRddCcIV");
                Assert.AreEqual(data.SimpleName, "Ji8zAsg");
                Assert.AreEqual(data.Contacts, "JOO");
                Assert.AreEqual(data.Phone, "zJdd");
                Assert.AreEqual(data.TypeOfEducation, SchoolManager.Model.BasicInfo.TypeOfEducationEnum.XQJY);
                Assert.AreEqual(data.Address, "5C1HL");
                Assert.AreEqual(data.TypeOfUrbanAndRural, SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZCQ);
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
       			
                v.ID = 59;
                v.Code = "y79oUK1sV";
                v.Name = "iACTwL8C8";
                v.EnglishName = "o77oL";
                v.PinyinName = "XGLn";
                v.SimplePinyinName = "jnRddCcIV";
                v.SimpleName = "Ji8zAsg";
                v.Contacts = "JOO";
                v.Phone = "zJdd";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.XQJY;
                v.Address = "5C1HL";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZCQ;
                context.Set<SchoolInfo>().Add(v);
                context.SaveChanges();
            }

            SchoolInfoVM vm = _controller.Wtm.CreateVM<SchoolInfoVM>();
            var oldID = v.ID;
            v = new SchoolInfo();
            v.ID = oldID;
       		
            v.Code = "ee2A";
            v.Name = "WiEs";
            v.EnglishName = "KALlJ";
            v.PinyinName = "hAY1VH";
            v.SimplePinyinName = "Wvl0aXP";
            v.SimpleName = "rzWhF4a";
            v.Contacts = "d5rF";
            v.Phone = "xEHnfhd4";
            v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.TSJY;
            v.Address = "XstyZ";
            v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZCQ;
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
 				
                Assert.AreEqual(data.Code, "ee2A");
                Assert.AreEqual(data.Name, "WiEs");
                Assert.AreEqual(data.EnglishName, "KALlJ");
                Assert.AreEqual(data.PinyinName, "hAY1VH");
                Assert.AreEqual(data.SimplePinyinName, "Wvl0aXP");
                Assert.AreEqual(data.SimpleName, "rzWhF4a");
                Assert.AreEqual(data.Contacts, "d5rF");
                Assert.AreEqual(data.Phone, "xEHnfhd4");
                Assert.AreEqual(data.TypeOfEducation, SchoolManager.Model.BasicInfo.TypeOfEducationEnum.TSJY);
                Assert.AreEqual(data.Address, "XstyZ");
                Assert.AreEqual(data.TypeOfUrbanAndRural, SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZCQ);
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
        		
                v.ID = 59;
                v.Code = "y79oUK1sV";
                v.Name = "iACTwL8C8";
                v.EnglishName = "o77oL";
                v.PinyinName = "XGLn";
                v.SimplePinyinName = "jnRddCcIV";
                v.SimpleName = "Ji8zAsg";
                v.Contacts = "JOO";
                v.Phone = "zJdd";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.XQJY;
                v.Address = "5C1HL";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZCQ;
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
				
                v1.ID = 59;
                v1.Code = "y79oUK1sV";
                v1.Name = "iACTwL8C8";
                v1.EnglishName = "o77oL";
                v1.PinyinName = "XGLn";
                v1.SimplePinyinName = "jnRddCcIV";
                v1.SimpleName = "Ji8zAsg";
                v1.Contacts = "JOO";
                v1.Phone = "zJdd";
                v1.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.XQJY;
                v1.Address = "5C1HL";
                v1.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZCQ;
                v2.ID = 58;
                v2.Code = "ee2A";
                v2.Name = "WiEs";
                v2.EnglishName = "KALlJ";
                v2.PinyinName = "hAY1VH";
                v2.SimplePinyinName = "Wvl0aXP";
                v2.SimpleName = "rzWhF4a";
                v2.Contacts = "d5rF";
                v2.Phone = "xEHnfhd4";
                v2.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.TSJY;
                v2.Address = "XstyZ";
                v2.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZCQ;
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
