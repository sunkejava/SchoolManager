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
    getStudentInfo;
    @State
    getStudentInfoData;

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
             "Entity.StartDate":{
                 label: "开始时间",
                 rules: [],
                    type: "datePicker"
            },
             "Entity.EndDate":{
                 label: "结束时间",
                 rules: [],
                    type: "datePicker"
            },
             "Entity.HonorId":{
                 label: "荣誉",
                 rules: [{ required: true, message: "荣誉"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: this.getHonorInfoData,
                    props: {
                        clearable: true
                    }
            },
             "Entity.StudentId":{
                 label: "学生",
                 rules: [{ required: true, message: "学生"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: this.getStudentInfoData,
                    props: {
                        clearable: true
                    }
            }
                
            }
        };
    }
    beforeOpen() {
        this.getHonorInfo();
        this.getStudentInfo();

    }
}
</script>
