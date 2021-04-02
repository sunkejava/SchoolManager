using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.GradeClassInfoVMs
{
    public partial class GradeClassInfoBatchVM : BaseBatchVM<GradeClassInfo, GradeClassInfo_BatchEdit>
    {
        public GradeClassInfoBatchVM()
        {
            ListVM = new GradeClassInfoListVM();
            LinkedVM = new GradeClassInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class GradeClassInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
