using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.SubjectInfoVMs
{
    public partial class SubjectInfoBatchVM : BaseBatchVM<SubjectInfo, SubjectInfo_BatchEdit>
    {
        public SubjectInfoBatchVM()
        {
            ListVM = new SubjectInfoListVM();
            LinkedVM = new SubjectInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class SubjectInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
