import{u as s,c as a,p as t,e as l,d as e,o as i,a as o,b as c,t as d,F as r,h as n,g as u,m}from"./vendor.6856a254.js";import{l as v,t as p,P as f,A as w}from"./index.43eddd1c.js";const g={setup:()=>(s((async()=>{try{await v.getAll(),await p.getAll()}catch(s){f.toast(s,"error")}})),{lists:a((()=>w.lists)),tasks:a((()=>w.tasks)),account:a((()=>w.account)),user:a((()=>w.user))})},h=u();t("data-v-affd5d26");const L={class:"container-fluid"},k={class:"row text-center "},x={class:"col-12 p-2"},y={class:"col-12 newList"},b=c("h3",null,"Make a new List?",-1),A=m(),j={class:"row pt-5 masonry-with-columns"};l();const C=h(((s,a,t,l,u,m)=>{const v=e("im"),p=e("List"),f=e("CreateList");return i(),o(r,null,[c("div",L,[c("div",k,[c("div",x,[c("h1",null,"Hello "+d(l.user.nickname),1)]),c("div",y,[b,A,c(v,{alt:"Create List",class:" grow hoverable mdi mdi-text-box-plus","data-toggle":"modal","data-target":"#createList"})])]),c("div",j,[(i(!0),o(r,null,n(l.lists,(s=>(i(),o("div",{class:"col-md-3",key:s.id},[c(p,{list:s},null,8,["list"])])))),128))])]),c(f)],64)}));g.render=C,g.__scopeId="data-v-affd5d26";export default g;
