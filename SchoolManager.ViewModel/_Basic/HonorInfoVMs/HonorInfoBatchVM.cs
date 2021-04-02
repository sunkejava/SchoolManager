using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.HonorInfoVMs
{
    public partial class HonorInfoBatchVM : BaseBatchVM<HonorInfo, HonorInfo_BatchEdit>
    {
        public HonorInfoBatchVM()
        {
            ListVM = new HonorInfoListVM();
            LinkedVM = new HonorInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class HonorInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
