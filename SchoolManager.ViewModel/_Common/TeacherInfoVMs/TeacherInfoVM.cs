using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Common.TeacherInfoVMs
{
    public partial class TeacherInfoVM : BaseCRUDVM<TeacherInfo>
    {

        public TeacherInfoVM()
        {
            SetInclude(x => x.Position);
            SetInclude(x => x.Title);
            SetInclude(x => x.TeacherProjects);
            SetInclude(x => x.StudentHonors);
            SetInclude(x => x.StudentSubjects);
            SetInclude(x => x.SchoolInfo);
            SetInclude(x => x.MajorInfo);
            SetInclude(x => x.GradeClass);
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
