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
import { TypeOfEducationTypes,TypeOfUrbanAndRuralTypes } from "../config";

@Component({
    mixins: [formMixin()]
})
export default class Index extends Vue {

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
             "Entity.EnglishName":{
                 label: "英文名称",
                 rules: [],
                    type: "input"
            },
             "Entity.PinyinName":{
                 label: "全拼名称",
                 rules: [{ required: true, message: "全拼名称"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.SimplePinyinName":{
                 label: "简拼名称",
                 rules: [{ required: true, message: "简拼名称"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.SimpleName":{
                 label: "简称",
                 rules: [{ required: true, message: "简称"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.Contacts":{
                 label: "联系人",
                 rules: [],
                    type: "input"
            },
             "Entity.Phone":{
                 label: "联系电话",
                 rules: [],
                    type: "input"
            },
             "Entity.TypeOfEducation":{
                 label: "教育类型",
                 rules: [{ required: true, message: "教育类型"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: TypeOfEducationTypes,
                    props: {
                        clearable: true
                    }
            },
             "Entity.Address":{
                 label: "地址",
                 rules: [],
                    type: "input"
            },
             "Entity.TypeOfUrbanAndRural":{
                 label: "驻地城乡类型",
                 rules: [{ required: true, message: "驻地城乡类型"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: TypeOfUrbanAndRuralTypes,
                    props: {
                        clearable: true
                    }
            }
                
            }
        };
    }
    beforeOpen() {

    }
}
</script>
