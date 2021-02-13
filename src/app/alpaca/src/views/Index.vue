<template>
    <a-page-header
        style="background: #FFF;"
        title="Title"
        sub-title="This is a subtitle"
        @back="() => $router.go(-1)"
    >
        <template #extra>
            <a-button key="3">Operation</a-button>
            <a-button key="2">Operation</a-button>
            <a-button key="1" type="primary">Primary</a-button>
        </template>
        <template #footer>
            <a-tabs default-active-key="1">
                <a-tab-pane key="1" tab="Details" />
                <a-tab-pane key="2" tab="Rule" />
            </a-tabs>
        </template>
        <div class="content">
            <div class="main">
                <a-descriptions size="small" :column="2">
                    <a-descriptions-item label="Created">Lili Qu</a-descriptions-item>
                    <a-descriptions-item label="Association">
                        <a>421421</a>
                    </a-descriptions-item>
                    <a-descriptions-item label="Creation Time">2017-01-10</a-descriptions-item>
                    <a-descriptions-item label="Effective Time">2017-10-10</a-descriptions-item>
                    <a-descriptions-item
                        label="Remarks"
                    >Gonghu Road, Xihu District, Hangzhou, Zhejiang, China</a-descriptions-item>
                </a-descriptions>
            </div>
            <div class="extra">
                <div
                    :style="{
                        display: 'flex',
                        width: 'max-content',
                        justifyContent: 'flex-end',
                    }"
                >
                    <a-statistic
                        title="Status"
                        value="Pending"
                        :style="{
                            marginRight: '32px',
                        }"
                    />
                    <a-statistic title="Price" prefix="$" :value="568.08" />
                </div>
            </div>
        </div>
    </a-page-header>
    <a-layout-content class="layout-content">占位，待编辑</a-layout-content>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
export default defineComponent({
    name: 'Index',
})
</script>

<script setup lang="ts">

</script>

<style scoped>
</style>
