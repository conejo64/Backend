import{H as t}from"./index.7427913b.js";const a="reminders";class c{async readCatalogs(e){const s=`${a}?page=${e.page}&pageSize=${e.pageSize}&QueryParam=${e.search}`;return await t.get(s)}async readCatalogsAll(){const e=`${a}/all`;return await t.get(e)}async readCatalog(e){const s=`${a}/${e}`;return await t.get(s)}async createCatalog(e){const s=`${a}`;return await t.post(s,e)}async updateCatalog(e){const s=`${a}/${e.id}`;return await t.put(s,e)}async deleteCatalog(e){const s=`${a}/${e}`;return await t.delete(s)}}export{c as R};
