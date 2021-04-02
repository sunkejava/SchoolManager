using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.PositionInfoVMs
{
    public partial class PositionInfoBatchVM : BaseBatchVM<PositionInfo, PositionInfo_BatchEdit>
    {
        public PositionInfoBatchVM()
        {
            ListVM = new PositionInfoListVM();
            LinkedVM = new PositionInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class PositionInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
