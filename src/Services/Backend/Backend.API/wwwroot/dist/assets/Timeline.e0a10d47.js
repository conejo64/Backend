import{_ as b,u as y,r as _,b as r,c as m,d as h,e as t,f as o,g as s,v as f,i as a,t as n,E as x,n as z,z as C,m as A,q as B,s as q}from"./index.7427913b.js";const i=u=>(B("data-v-3bebd089"),u=u(),q(),u),T={class:"grid"},w={class:"col-6"},k={class:"card"},S=i(()=>t("h5",null,"Left Align",-1)),I={class:"col-6"},E={class:"card"},N=i(()=>t("h5",null,"Right Align",-1)),V={class:"col-6"},D={class:"card"},F=i(()=>t("h5",null,"Alternate Align",-1)),L={class:"col-6"},j={class:"card"},O=i(()=>t("h5",null,"Opposite Content",-1)),R={class:"p-text-secondary"},H={class:"card"},G=i(()=>t("h5",null,"Custom Timeline",-1)),J=["src","alt"],K=i(()=>t("p",null," Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque quas! ",-1)),M={class:"card mt-3"},Q=i(()=>t("h5",null,"Horizontal",-1)),U=i(()=>t("h6",null,"Top Align",-1)),W=i(()=>t("h6",null,"Bottom Align",-1)),X=i(()=>t("h6",null,"Alternate Align",-1)),Y={__name:"Timeline",setup(u){const{contextPath:p}=y(),c=_([{status:"Ordered",date:"15/10/2020 10:30",icon:"pi pi-shopping-cart",color:"#9C27B0",image:"game-controller.jpg"},{status:"Processing",date:"15/10/2020 14:00",icon:"pi pi-cog",color:"#673AB7"},{status:"Shipped",date:"15/10/2020 16:15",icon:"pi pi-envelope",color:"#FF9800"},{status:"Delivered",date:"16/10/2020 10:00",icon:"pi pi-check",color:"#607D8B"}]),d=_(["2020","2021","2022","2023"]);return(Z,$)=>{const l=r("Timeline",!0),v=r("Button"),g=r("Card");return m(),h(f,null,[t("div",T,[t("div",w,[t("div",k,[S,o(l,{value:c.value},{content:s(e=>[a(n(e.item.status),1)]),_:1},8,["value"])])]),t("div",I,[t("div",E,[N,o(l,{value:c.value,align:"right"},{content:s(e=>[a(n(e.item.status),1)]),_:1},8,["value"])])]),t("div",V,[t("div",D,[F,o(l,{value:c.value,align:"alternate"},{content:s(e=>[a(n(e.item.status),1)]),_:1},8,["value"])])]),t("div",L,[t("div",j,[O,o(l,{value:c.value},{opposite:s(e=>[t("small",R,n(e.item.date),1)]),content:s(e=>[a(n(e.item.status),1)]),_:1},8,["value"])])])]),t("div",H,[G,o(l,{value:c.value,align:"alternate",class:"customized-timeline"},{marker:s(e=>[t("span",{class:"flex w-2rem h-2rem align-items-center justify-content-center text-white border-circle z-1 shadow-2",style:x({backgroundColor:e.item.color})},[t("i",{class:z(e.item.icon)},null,2)],4)]),content:s(e=>[o(g,null,{title:s(()=>[a(n(e.item.status),1)]),subtitle:s(()=>[a(n(e.item.date),1)]),content:s(()=>[e.item.image?(m(),h("img",{key:0,src:C(p)+"demo/images/product/"+e.item.image,alt:e.item.name,width:"200",class:"shadow-2 mb-3"},null,8,J)):A("",!0),K,o(v,{label:"Read more",class:"p-button-text"})]),_:2},1024)]),_:1},8,["value"])]),t("div",M,[Q,U,o(l,{value:d.value,layout:"horizontal",align:"top"},{content:s(e=>[a(n(e.item),1)]),_:1},8,["value"]),W,o(l,{value:d.value,layout:"horizontal",align:"bottom"},{content:s(e=>[a(n(e.item),1)]),_:1},8,["value"]),X,o(l,{value:d.value,layout:"horizontal",align:"alternate"},{opposite:s(()=>[a(" \xA0 ")]),content:s(e=>[a(n(e.item),1)]),_:1},8,["value"])])],64)}}},ee=b(Y,[["__scopeId","data-v-3bebd089"]]);export{ee as default};
