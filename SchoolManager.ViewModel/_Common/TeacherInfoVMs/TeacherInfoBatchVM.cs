using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;


namespace SchoolManager.ViewModel._Common.TeacherInfoVMs
{
    public partial class TeacherInfoBatchVM : BaseBatchVM<TeacherInfo, TeacherInfo_BatchEdit>
    {
        public TeacherInfoBatchVM()
        {
            ListVM = new TeacherInfoListVM();
            LinkedVM = new TeacherInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class TeacherInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
