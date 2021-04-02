using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.MajorInfoVMs
{
    public partial class MajorInfoBatchVM : BaseBatchVM<MajorInfo, MajorInfo_BatchEdit>
    {
        public MajorInfoBatchVM()
        {
            ListVM = new MajorInfoListVM();
            LinkedVM = new MajorInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class MajorInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
