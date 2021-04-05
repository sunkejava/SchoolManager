using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.MajorMiddleInfo;
using SchoolManager.Model.BasicInfo;
using SchoolManager.Model.Business;


namespace SchoolManager.ViewModel._Common.MajorManagerVMs
{
    public partial class MajorManagerVM : BaseCRUDVM<MajorManager>
    {

        public MajorManagerVM()
        {
            SetInclude(x => x.Honor);
            SetInclude(x => x.Student);
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
