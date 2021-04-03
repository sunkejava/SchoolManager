<template>
    <card>
        <wtm-search-box :ref="searchRefName" :events="searchEvent" :formOptions="SEARCH_DATA" :needCollapse="true" :isActive.sync="isActive" />
        <!-- 操作按钮 -->
        <wtm-but-box :assembly="assembly" :action-list="actionList" :selected-data="selectData" :events="actionEvent" />
        <!-- 列表 -->
        <wtm-table-box :attrs="{...searchAttrs, actionList}" :events="{...searchEvent, ...actionEvent}">
      <template #PhotoId="rowData">
        <el-image v-if="!!rowData.row.PhotoId" style="width: 100px; height: 100px" :src="'/api/_file/downloadFile/'+rowData.row.PhotoId" fit="cover" />
      </template>


        </wtm-table-box>
        <!-- 弹出框 -->
        <dialog-form :is-show.sync="dialogIsShow" :dialog-data="dialogData" :status="dialogStatus" @onSearch="onHoldSearch" />
        <!-- 导入 -->
        <upload-box :is-show.sync="uploadIsShow" @onImport="onImport" @onDownload="onDownload" />
    </card>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import searchMixin from "@/vue-custom/mixin/search";
import actionMixin from "@/vue-custom/mixin/action-mixin";
import DialogForm from "./views/dialog-form.vue";
import store from "./store/index";
// 查询参数, table列 ★★★★★
import { ASSEMBLIES, TABLE_HEADER,  } from "./config";
import i18n from "@/lang";

@Component({
    name: "studentinfo",
    mixins: [searchMixin(TABLE_HEADER), actionMixin(ASSEMBLIES)],
    store,
    components: {
        DialogForm
    }
})
export default class Index extends Vue {
    isActive: boolean = false;
    @Action
    getMajorInfo;
    @State
    getMajorInfoData;
    @Action
    getGradeClassInfo;
    @State
    getGradeClassInfoData;

    get SEARCH_DATA() {
        return {
            formProps: {
                "label-width": "75px",
                inline: true
            },
            formItem: {
                "InTake":{
                    label: "入学时间",
                    rules: [],
                    type: "datePicker",
                    span: 12,
                    props: {
                            type: "datetimerange",
                        "value-format": "yyyy-MM-dd HH:mm:ss",
                        "range-separator": "-",
                        "start-placeholder": this.$t("table.startdate"),
                        "end-placeholder": this.$t("table.enddate")
                    }
              },
                "Code":{
                    label: "代码",
                    rules: [],
                    type: "input"
              },
                "Name":{
                    label: "名称",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "CellPhone":{
                    label: "联系电话",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "ZipCode":{
                    label: "邮编",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "EmContacts":{
                    label: "紧急联系人",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "EmConPhone":{
                    label: "联系人电话",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "MajorInfoId":{
                    label: "专业",
                    rules: [],
                    type: "select",
                    children: this.getMajorInfoData,
                    props: {
                        clearable: true,
                        placeholder: '全部'
                    }
                    ,isHidden: !this.isActive
              },
                "GradeClassId":{
                    label: "班级",
                    rules: [],
                    type: "select",
                    children: this.getGradeClassInfoData,
                    props: {
                        clearable: true,
                        placeholder: '全部'
                    }
                    ,isHidden: !this.isActive
              },

            }
        };
    }

     mounted() {
        this.getMajorInfo();
        this.getGradeClassInfo();

    }
}
</script>
