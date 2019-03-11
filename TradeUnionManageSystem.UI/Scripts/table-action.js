window.onload = function () {

    InitBtnExcelExport();

    document.getElementById("btnPrint").addEventListener("click", function () {
        InitBtnPrint();
    });

};


// 初始化导出按钮
function InitBtnExcelExport() {
    // 使用outerHTML属性获取整个table元素的HTML代码（包括<table>标签），然后包装成一个完整的HTML文档，设置charset为urf-8以防止中文乱码
    var html = "<html><head><meta charset='utf-8' /></head><body>" + document.getElementsByTagName("table")[0].outerHTML + "</body></html>";
    // 实例化一个Blob对象，其构造函数的第一个参数是包含文件内容的数组，第二个参数是包含文件类型属性的对象
    var blob = new Blob([html], { type: "application/vnd.ms-excel" });
    var a = document.getElementById("btnExport");
    // 设置文件名
    a.download = "导出文件.xls";
    // 利用URL.createObjectURL()方法为a元素生成blob URL
    a.href = URL.createObjectURL(blob);
}

// 初始化打印按钮
function InitBtnPrint() {
    bdhtml = document.getElementById("tableTest").outerHTML;
    sprnstr = "<!--startprint-->"; //开始打印标识字符串有17个字符
    eprnstr = "<!--endprint-->"; //结束打印标识字符串    
    prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17); //从开始打印标识之后的内容
    prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr)); //截取开始标识和结束标识之间的内容

    var newWin = window.open("");//新打开一个空窗口
    newWin.document.close();//在IE浏览器中使用必须添加这一句
    newWin.focus();//在IE浏览器中使用必须添加这一句
    newWin.document.body.innerText = "";//先清空iframe原先的内容
    newWin.document.write(bdhtml);
    newWin.print(); //调用浏览器的打印功能打印指定区域
    newWin.close();
}