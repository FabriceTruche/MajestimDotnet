
function tvBuild(tvName) {
    var rows = getRows(tvName);
    var parents = [null];

    // expands
    var onClickAttribute = "onButtonClick();";
    //var expandInnerHTML = '<td width="50px"><span tv-icon="1" class="glyphicon glyphicon-triangle-bottom"></span></td>';
    //var expandInnerHTML = '<span tv-icon="1" class="glyphicon glyphicon-triangle-bottom">';
    //var expandInnerHTML = '<span tv-icon class="btn btn-outline-primary tv-icon"></span>';
    //var expandInnerHTML = '<span tv-icon class="fas far fa-file fa-folder fa-folder-open" style="font-size: 10px">&nbsp;&nbsp;</span>';
    //var expandInnerHTML = '<span tv-icon class="fas fa-angle-right fa-angle-down" style="font-size: 10px"></span>';

    var expandInnerHTML = '<span tv-icon class="fas tv-icon"></span>';
    var textFirstTdHML = "<span></span>";

    var items;
    var node;
    var val;
    var elt;

    //g_tvName = tvName;

    for (var j = 0; j < rows.length; j++) {
        node = rows[j];
        node.setAttribute("onClick", onClickAttribute);
        elt = getFirstTd(node);
        var textFirst = elt.childNodes[0];
        elt.classList.toggle("first-column", true);
        //elt.classList = ["first-column"];
        elt.insertAdjacentHTML("afterbegin", expandInnerHTML);
        elt.insertAdjacentHTML("beforeend", textFirstTdHML);
        var lastChild = elt.lastElementChild;
        lastChild.appendChild(textFirst);
        // elt = elt.lastElementChild;
        //  elt.appendChild(textFirst);
    }

    // tree
    for (var i = 0; i < rows.length; i++) {
        var level = getLevel(rows[i]);
        var parent = parents[level - 1];
        var row = rows[i];

        row._tvParent = parent;
        row._tvExpand = true;
        row._tvVisible = true;
        row._tvLevel = level;

        if (parent != null) {
            if (parents[level - 1]._tvChildren === undefined)
                parents[level - 1]._tvChildren = [];
            parents[level - 1]._tvChildren.push(row);
        }

        parents[level] = row;

        // padding
        if (level > 1) {
            var padding = ((level - 1) * 30).toString() + "px";
            var itemCell = row._tvCell;

            itemCell.style.paddingLeft = padding;
        }
    }

    // icon
    items = $("[tv-icon]");
    var htmlRow;

    for (var j = 0; j < items.length; j++) {
        node = items[j];
        htmlRow = getHtmlRow(node);
        val = htmlRow.getAttribute("onClick");

        if (val === "onButtonClick();") {
            htmlRow._tvIcon = node;
            toggleIcon(htmlRow._tvIcon, htmlRow._tvChildren === undefined, htmlRow._tvChildren != undefined && htmlRow._tvExpand);
        }
    }

    // collaspe all rows
    // bug
    // collapseAllRows(rows);
}

function toggleIcon(node, noChildren, expand) {
    //	node.classList.toggle("fas", !noChildren)
    //	node.classList.toggle("far", noChildren);

    // if (noChildren)
    // node.innerHTML="&nbsp;";
    // else if (expand)
    // node.textContent="-";
    // else
    // node.textContent="+";

    // node.classList.toggle("minus", noChildren);
    node.classList.toggle("fa-angle-down", (!noChildren) && (!expand));
    node.classList.toggle("fa-angle-right", (!noChildren) && expand);
    node.classList.toggle("tv-no-child", noChildren);

    // if (!noChildren)
    // node.style.fontSize = "10px"
    // else
    // node.style.fontSize = "10px"
}


function collapseAllRows(rows) {
    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        if (row._tvLevel === 1) {
            row._tvExpand = false;
            redrawRows(false, row);
        }
    }
}


function getLevel(row) {
    return parseInt(row.getAttribute("tv-level"));
}

function getRows(tag) {
    var rows = [];

    var root = document.getElementById(tag);
    for (var i = 0; i < root.children.length; i++) {
        if (root.children[i].nodeType === 1) {
            var item = root.children[i];
            rows.push(item);

            // on affecte la cell du button (on skip le texte)
            var tvCell = item.children[0];
            item._tvCell = tvCell;
        }
    }

    return rows;
}

function getHtmlRow(node) {
    var p = node.parentNode;

    while (p.parentNode != null) {
        if (p.localName === "tr")
            return p;
        p = p.parentNode;
    }

    return null;
}

function getFirstTd(node) {
    var items = node.children;

    for (var i = 0; i < items.length; i++) {
        var subItem = items[i];
        if (subItem.localName === "td")
            return subItem;

        subItem = getFirstTd(subItem);
        if (subItem != null)
            return subItem;
    }

    return null;
}

function onButtonClick() {
    var row = getHtmlRow(event.srcElement);

    if (row == null)
        return;

    if (row._tvChildren === undefined) {
        toggleIcon(row._tvIcon, true, false);
        return;
    }

    row._tvExpand = !row._tvExpand;

    redrawRows(row._tvExpand, row);
    //Dump('---------------------- >>>');

    toggleIcon(row._tvIcon, false, row._tvExpand);

    //row._tvIcon.classList = ["fas fas-caret-" + (row._tvExpand ? "down" : "right")];
}

// function setClassList(list, cls)
// {
// list.clear();
// list.add("fas");
// for(var i=0; i<list.length; i++)
// {
// list.add(
// }
// }

//function Dump(text) {
//    var items = getRows(g_tvName);
//    console.log(text);
//    for (var i = 0; i < items.length; i++) {
//        console.log(i + " => (expand, visible) = " + items[i]._tvExpand + " , " + items[i]._tvVisible);
//    }
//}


function redrawRows(expand, row) {
    if (row._tvChildren === undefined)
        return;

    for (var i = 0; i < row._tvChildren.length; i++) {
        var item = row._tvChildren[i];
        var disp;

        item._tvVisible = row._tvExpand && expand;

        if (item._tvVisible)
            disp = "table-row";
        else
            disp = "none";

        item.style.display = disp;

        // childrens
        redrawRows(expand && item._tvVisible, item);
    }
}