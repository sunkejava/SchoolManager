using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.GradeInfoVMs
{
    public partial class GradeInfoBatchVM : BaseBatchVM<GradeInfo, GradeInfo_BatchEdit>
    {
        public GradeInfoBatchVM()
        {
            ListVM = new GradeInfoListVM();
            LinkedVM = new GradeInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class GradeInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
