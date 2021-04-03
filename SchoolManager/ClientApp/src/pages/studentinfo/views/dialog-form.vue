<template>
    <wtm-dialog-box :is-show.sync="isShow" :status="status" :events="formEvent">
        <wtm-create-form :ref="refName" :status="status" :options="formOptions" ></wtm-create-form>
    </wtm-dialog-box>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import formMixin from "@/vue-custom/mixin/form-mixin";
import UploadImg from "@/components/page/UploadImg.vue";


@Component({
    mixins: [formMixin()]
})
export default class Index extends Vue {
    @Action
    getHonorInfo;
    @State
    getHonorInfoData;
    @Action
    getSubjectInfo;
    @State
    getSubjectInfoData;
    @Action
    getSchoolInfo;
    @State
    getSchoolInfoData;
    @Action
    getMajorInfo;
    @State
    getMajorInfoData;
    @Action
    getGradeClassInfo;
    @State
    getGradeClassInfoData;

    // 表单结构
    get formOptions() {
        const filterMethod = (query, item) => {
            return item.label.indexOf(query) > -1;
        };
        return {
            formProps: {
                "label-width": "100px"
            },
            formItem: {
                "Entity.ID": {
                    isHidden: true
                },
             "Entity.InTake":{
                 label: "入学时间",
                 rules: [{ required: true, message: "入学时间"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "datePicker"
            },
             "Entity.StudentHonors":{
                 label: "学生荣誉",
                 rules: [],
                    type: "transfer",
                    mapKey: "HonorId",
                    props: {
                        data: this.getHonorInfoData.map(item => ({
                            key: item.Value,
                            label: item.Text
                        })),
                        titles: [this.$t("form.all"), this.$t("form.selected")],
                        filterable: true,
                        filterMethod: filterMethod
                    },
                    span: 24,
                    defaultValue: []
            },
             "Entity.StudentSubjects":{
                 label: "学生科目",
                 rules: [],
                    type: "transfer",
                    mapKey: "SubjectId",
                    props: {
                        data: this.getSubjectInfoData.map(item => ({
                            key: item.Value,
                            label: item.Text
                        })),
                        titles: [this.$t("form.all"), this.$t("form.selected")],
                        filterable: true,
                        filterMethod: filterMethod
                    },
                    span: 24,
                    defaultValue: []
            },
             "Entity.Code":{
                 label: "代码",
                 rules: [{ required: true, message: "代码"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.Name":{
                 label: "名称",
                 rules: [{ required: true, message: "名称"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.CellPhone":{
                 label: "联系电话",
                 rules: [],
                    type: "input"
            },
             "Entity.ZipCode":{
                 label: "邮编",
                 rules: [],
                    type: "input"
            },
             "Entity.EmContacts":{
                 label: "紧急联系人",
                 rules: [],
                    type: "input"
            },
             "Entity.EmConPhone":{
                 label: "联系人电话",
                 rules: [],
                    type: "input"
            },
             "Entity.SchoolInfoId":{
                 label: "毕业院校",
                 rules: [{ required: true, message: "毕业院校"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: this.getSchoolInfoData,
                    props: {
                        clearable: true
                    }
            },
             "Entity.MajorInfoId":{
                 label: "专业",
                 rules: [{ required: true, message: "专业"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: this.getMajorInfoData,
                    props: {
                        clearable: true
                    }
            },
             "Entity.PhotoId":{
                 label: "照片",
                 rules: [],
                type: "wtmUploadImg",
                    props: {
                        isHead: true,
                        imageStyle: { width: "100px", height: "100px" }
                    }

            },
             "Entity.GradeClassId":{
                 label: "班级",
                 rules: [{ required: true, message: "班级"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: this.getGradeClassInfoData,
                    props: {
                        clearable: true
                    }
            }
                
            }
        };
    }
    beforeOpen() {
        this.getHonorInfo();
        this.getSubjectInfo();
        this.getSchoolInfo();
        this.getMajorInfo();
        this.getGradeClassInfo();

    }
}
</script>
