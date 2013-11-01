{0}
@section currentPageJs{{
        @Scripts.Render("~/Scripts/commonPage.js")
}}
<table id="dg" class="easyui-datagrid" border="0" pagination="true" fit="true"
    data-options="
                toolbar: '#tb',
                onClickRow: onClickRow,
                remoteSort:false,
                singleSelect: true,
                multiSort:false,
                sortName:'ID',
                url: 'GetDataList'">
    <thead>
        <tr>
            {1}
        </tr>
    </thead>
</table>
<div id="tb" style="height: auto">
    <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="addData()">添加</a>
    <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-edit',plain:true" onclick="editData()">修改</a>
    <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true" onclick="delData()">删除</a>
    <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true" onclick="openAdminAuthority()">查看模块对应的权限</a>
</div>
<div id="AdminModuleWin" class="easyui-window" title="用户信息" data-options="modal:true,closed:true,iconCls:'icon-save'"
    style="width: 400px; height: 300px; padding: 10px;">
    <div style="padding: 10px 0 10px 35px">
        @using (Ajax.BeginForm("CreateOrUpdate", "{2}",
            new AjaxOptions {{ OnSuccess = "success", OnFailure = "failure" }},
            new {{ @id = "{3}" }}))
        {{
           <table>
            {4}
            </table>  
        }}
    </div>
    <div style="text-align: center; padding: 5px">
        <a href="javascript:void(0)" data-options="iconCls:'icon-ok'" class="easyui-linkbutton" onclick="submitForm()">保存</a>
        <a href="javascript:void(0)" data-options="iconCls:'icon-reload'" class="easyui-linkbutton" onclick="clearForm()">清空</a>
    </div>
</div>