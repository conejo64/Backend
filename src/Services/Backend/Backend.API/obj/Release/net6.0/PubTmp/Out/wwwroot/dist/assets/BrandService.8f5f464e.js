import{H as a}from"./index.7427913b.js";const t="brands";class c{async readCatalogs(e){const s=`${t}?page=${e.page}&pageSize=${e.pageSize}&QueryParam=${e.search}`;return await a.get(s)}async readCatalogsAll(){const e=`${t}/all`;return await a.get(e)}async readCatalog(e){const s=`${t}/${e}`;return await a.get(s)}async createCatalog(e){const s=`${t}`;return await a.post(s,e)}async updateCatalog(e){const s=`${t}/${e.id}`;return await a.put(s,e)}async deleteCatalog(e){const s=`${t}/${e}`;return await a.delete(s)}}export{c as B};