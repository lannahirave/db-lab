
//------------------------------------------------------------------------
//
// Generated by www.easywsdl.com
// Version: 8.0.1.0
//
// Created by Quasar Development 
//
// This class has been generated for test purposes only and cannot be used in any commercial project.
// To use it in commercial project, you need to generate this class again with Premium account.
// Check https://EasyWsdl.com/Payment/PremiumAccountDetails to see all benefits of Premium account.
//
// Licence: CA3F4CEB7486F6668BD6F181D6CA68F608603F641897C20DF217C55FE3F3416F64E665190F35F5CE91CF8F38D5FB78FB96170CE35D755393898FFBDA2F093BF2
//------------------------------------------------------------------------
part of com.example.testSoap.wcf;


class GQBArrayOfRowCell extends ListBase< GQBRowCell> implements GQBISerializableObject
{
    List< GQBRowCell> innerList = List.empty(growable: true);
    
    XmlElement?  __source;

    XmlElement? getOriginalXmlSource(){
        return __source;
    }

    @override
    int get length => innerList.length;

    @override
    void set length(int length) {
        innerList.length = length;
    }
    
    @override
    void operator[]=(int index, GQBRowCell value) {
        innerList[index] = value;
    }
    
    @override
    GQBRowCell operator [](int index) => innerList[index];

    @override
    void add(GQBRowCell value) => innerList.add(value);

    @override
    void addAll(Iterable< GQBRowCell> all) => innerList.addAll(all);

    @override
    Future<void> loadWithXml(XmlElement __node, GQBRequestResultHandler __handler) async
    {
        __source=__node;
        for(int i=0;i < __node.children.length;i++)
        {
            var __child=__node.children[i];
            if(__child is XmlElement)
            {
                if(!await loadProperty(__child,__handler))
                {
                }
            }
        }
    }
    
    Future<bool> loadProperty(XmlElement __node, GQBRequestResultHandler __handler) async
    {
        if (__node.name.local == "RowCell")
        {
            innerList.add(await __handler.createObject(__node,  () =>GQBRowCell()) as GQBRowCell);
            return true;
        }
        return false;
    }

    @override
    Future<void> serialize(XmlElement __node, GQBRequestResultHandler __handler) async
    {
        for (var item in innerList)
        {
            var propertyElement=__handler.writeElementWithType(item, GQBRowCell, "RowCell", "http://schemas.datacontract.org/2004/07/DB.WebService.Contract", __node, false);
            if (propertyElement != null)
            {
                await item.serialize(propertyElement,__handler);
            }
        }
    }
}