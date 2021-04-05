<template>
    <card>
        <wtm-search-box :ref="searchRefName" :events="searchEvent" :formOptions="SEARCH_DATA" :needCollapse="true" :isActive.sync="isActive" />
        <!-- 操作按钮 -->
        <wtm-but-box :assembly="assembly" :action-list="actionList" :selected-data="selectData" :events="actionEvent" />
        <!-- 列表 -->
        <wtm-table-box :attrs="{...searchAttrs, actionList}" :events="{...searchEvent, ...actionEvent}">

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
import { ASSEMBLIES, TABLE_HEADER, TypeOfEducationTypes,TypeOfUrbanAndRuralTypes } from "./config";
import i18n from "@/lang";

@Component({
    name: "schoolinfo",
    mixins: [searchMixin(TABLE_HEADER), actionMixin(ASSEMBLIES)],
    store,
    components: {
        DialogForm
    }
})
export default class Index extends Vue {
    isActive: boolean = false;

    get SEARCH_DATA() {
        return {
            formProps: {
                "label-width": "75px",
                inline: true
            },
            formItem: {
                "Code":{
                    label: "代码",
                    rules: [],
                    type: "input"
              },
                "Name":{
                    label: "名称",
                    rules: [],
                    type: "input"
              },
                "EnglishName":{
                    label: "英文名称",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "PinyinName":{
                    label: "全拼名称",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "SimplePinyinName":{
                    label: "简拼名称",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "SimpleName":{
                    label: "简称",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "Contacts":{
                    label: "联系人",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "Phone":{
                    label: "联系电话",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "TypeOfEducation":{
                    label: "教育类型",
                    rules: [],
                    type: "select",
                    children: TypeOfEducationTypes,
                    props: {
                        clearable: true,
                        placeholder: this.$t("form.all")
                    }
                    ,isHidden: !this.isActive
              },
                "Address":{
                    label: "地址",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "TypeOfUrbanAndRural":{
                    label: "驻地城乡类型",
                    rules: [],
                    type: "select",
                    children: TypeOfUrbanAndRuralTypes,
                    props: {
                        clearable: true,
                        placeholder: this.$t("form.all")
                    }
                    ,isHidden: !this.isActive
              },

            }
        };
    }

     mounted() {

    }
}
</script>
