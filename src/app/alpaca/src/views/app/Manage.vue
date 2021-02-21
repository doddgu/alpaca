<template>
    <a-page-header
        style="background: #fff;"
        :title="$t(store.state.currentMenu.title)"
        :sub-title="$t('text.appSubTitle')"
    >
        <template #extra>
            <a-button :loading="loadingData" @click="loadData">
                <template #icon>
                    <ReloadOutlined />
                </template>
                {{ $t('text.reload') }}
            </a-button>
            <a-button type="primary" @click="create">
                <template #icon>
                    <PlusOutlined />
                </template>
                {{ $t('text.create') }}
            </a-button>
        </template>
    </a-page-header>
    <a-layout-content class="layout-content">
        <a-spin :spinning="spinning">
            <a-table :dataSource="data" :columns="columns" rowKey="id">
                <template #operation="{ record }">
                    <a-button type="link" style="padding-left: 0px;" @click="edit(record)">
                        <template #icon>
                            <EditOutlined />
                        </template>
                        {{ $t('text.edit') }}
                    </a-button>
                </template>
            </a-table>
        </a-spin>
    </a-layout-content>
    <a-drawer
        :title="$t(editorType == EditorType.Create ? 'text.create' : 'text.edit')"
        :width="360"
        :visible="showEditorDrawer"
        :body-style="{ paddingBottom: '80px' }"
        @close="showEditorDrawer = false"
    >
        <a-form :model="editorModel" layout="vertical">
            <a-row :gutter="16">
                <a-col :span="24">
                    <a-form-item :label="$t('text.name')" name="name">
                        <a-input v-model:value="editorModel.name" />
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row :gutter="16">
                <a-col :span="24">
                    <a-form-item :label="$t('text.verifyMissingDays')" name="verifyMissingDays">
                        <a-input-number
                            id="verifyMissingDays"
                            v-model:value="editorModel.verifyMissingDays"
                            :min="1"
                            :max="36500"
                            style="width: 100%;"
                        />
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row :gutters="16">
                <a-col :span="24">
                    <a-form-item :label="$t('text.appEnvironment')" name="appEnvironmentList">
                        <div :style="{ borderBottom: '1px solid #E9E9E9' }">
                            <a-checkbox
                                v-model:checked="checkAllAppEnvironmentList"
                                :indeterminate="indeterminateCheckAllAppEnvironmentList"
                                @change="onCheckAllAppEnvironmentListChange"
                            >{{ $t('text.checkAll') }}</a-checkbox>
                        </div>
                        <a-checkbox-group
                            v-model:value="editorModel.appEnvironmentList"
                            :options="environmentList"
                        >
                            <template #label="{ name }">{{ name }}</template>
                        </a-checkbox-group>
                    </a-form-item>
                </a-col>
            </a-row>
        </a-form>
        <div
            :style="{
                position: 'absolute',
                right: 0,
                bottom: 0,
                width: '100%',
                borderTop: '1px solid #e9e9e9',
                padding: '10px 16px',
                background: '#fff',
                textAlign: 'right',
                zIndex: 1,
            }"
        >
            <a-button
                style="margin-right: 8px"
                @click="showEditorDrawer = false"
            >{{ $t('text.cancel') }}</a-button>
            <a-button :loading="loadingSave" type="primary" @click="save">{{ $t('text.save') }}</a-button>
        </div>
    </a-drawer>
</template>

<script lang="ts">
import { defineComponent, watch, ref } from 'vue'
import { useStore } from 'vuex'
import { message } from 'ant-design-vue'
export default defineComponent({
    name: 'Manage',
})
</script>

<script setup lang="ts">
import RootState from '../../store/RootState'
import axios from 'axios'
import ConfigAppViewModel from '../../model/services/config/ConfigApp/ConfigAppViewModel'
import UpdateConfigAppViewModel from '../../model/services/config/ConfigApp/UpdateConfigAppViewModel'
import ConfigEnvironmentViewModel from '../../model/services/config/ConfigEnvironment/ConfigEnvironmentViewModel'
import I18nHelper from '../../infrastructure/robust/helpers/I18nHelper'
import moment from 'moment'
import { EditorType } from '../../model/enums/EditorType'
import _ from 'lodash'

const store = useStore<RootState>()
ref: loadingData = false
ref: loadingSave = false
ref: data = [] as ConfigAppViewModel[]
ref: showEditorDrawer = false
ref: editorModel = new UpdateConfigAppViewModel()
ref: editorType = EditorType.Create
ref: checkAllAppEnvironmentList = false
ref: indeterminateCheckAllAppEnvironmentList = true
ref: environmentList = [] as ConfigEnvironmentViewModel[]
ref: spinning = false

const columns = [
    {
        title: I18nHelper.t('text.name'),
        dataIndex: 'name',
        key: 'name',
    },
    {
        title: I18nHelper.t('text.verifyMissingDays'),
        dataIndex: 'verifyMissingDays',
        key: 'verifyMissingDays',
    },
    {
        title: I18nHelper.t('text.updateUserName'),
        dataIndex: 'updateUserName',
        key: 'updateUserName',
    },
    {
        title: I18nHelper.t('text.updateTime'),
        dataIndex: 'updateTime',
        key: 'updateTime',
        customRender: (val: any) => {
            return val ? moment(val.text).format('YYYY-MM-DD HH:mm:ss') : ''
        }
    },
    {
        title: I18nHelper.t('text.operation'),
        key: 'operation',
        width: 160,
        slots: { customRender: 'operation' }
    }
]

function loadData() {
    loadingData = true

    axios
        .get('api/ConfigEnvironment/GetList')
        .then((resp: any) => {
            environmentList = _.map(resp.data, data => Object.assign(data, data, { value: data.id }))
        })

    axios
        .get('api/ConfigApp/GetList')
        .then((resp: any) => {
            data = resp.data
        })
        .finally(() => {
            loadingData = false
        })
}

function create() {
    editorType = EditorType.Create
    editorModel = new UpdateConfigAppViewModel()
    showEditorDrawer = true
}

function edit(record: ConfigAppViewModel) {
    editorType = EditorType.Edit
    spinning = true

    axios
        .get('api/ConfigApp?ID=' + record.id)
        .then((resp: any) => {
            editorModel = resp.data
            spinning = false
            showEditorDrawer = true
        })
}

function save() {
    if (!editorModel.name) {
        message.error(I18nHelper.dt('template.required', { name: I18nHelper.t('text.name') }))
        return
    }

    if (editorModel.name.length < 1 || editorModel.name.length > 50) {
        message.error(I18nHelper.dt('template.range',
            {
                name: I18nHelper.t('text.name'),
                min: 1,
                max: 50
            }))
        return
    }

    if (!editorModel.verifyMissingDays) {
        message.error(I18nHelper.dt('template.numberRange', { name: I18nHelper.t('text.verifyMissingDays'), min: 1, max: 36500 }))
        return
    }

    loadingSave = true

    switch (editorType) {
        case EditorType.Create:
            axios
                .post('/api/ConfigApp', editorModel)
                .then((resp: any) => {
                    loadData()
                    showEditorDrawer = false
                    message.success(I18nHelper.t('text.ss'))
                })
                .finally(() => {
                    loadingSave = false
                })
            break;
        case EditorType.Edit:
            axios
                .put('/api/ConfigApp', editorModel)
                .then((resp: any) => {
                    loadData()
                    showEditorDrawer = false
                    message.success(I18nHelper.t('text.ss'))
                })
                .finally(() => {
                    loadingSave = false
                })
        default:
            break;
    }
}

function onCheckAllAppEnvironmentListChange(e: any) {
    editorModel.appEnvironmentList = e.target.checked ? _.map(environmentList, 'id') : []
}

watch(
    () => editorModel.appEnvironmentList,
    val => {
        indeterminateCheckAllAppEnvironmentList = !!val.length && val.length < environmentList.length;
        checkAllAppEnvironmentList = val.length === environmentList.length;
    },
)

loadData()
</script>

<style scoped>
</style>
