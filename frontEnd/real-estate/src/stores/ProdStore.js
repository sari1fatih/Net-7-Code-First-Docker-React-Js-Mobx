import { makeObservable, observable, action } from "mobx";
import UserSessionStore from './UserSessionStore'
import Service from '../utils/api/services'

class ProdStore {
  listProducts = [];
   
  constructor() {
    makeObservable(this, {
      listProducts:observable,
      getList: action
    });
  }
  
  async getList  () { 
    try { 
          var search = UserSessionStore.getQueryString(); 
          console.log('a->',search)
          var result = await Service.GET(`${search}`); 
          if (!!result?.data && Array.isArray(result.data)) {
            this.listProducts=result.data
          }
    } catch (error) {
        
    } 
  } 
} 


export default new ProdStore();