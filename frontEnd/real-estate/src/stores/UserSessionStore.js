import ProdStore from './ProdStore'

class UserSessionStore { 
    pageSize = 10;
    pageNumber = 1;
    minPrice = 0;
    maxPrice = 0;
    search = "";
    selectListBuildingAge = [];
    selectListFloorLevel = [];
    selectListFurniteCondition = [];
    selectListNumberOfRooms = [];
    selectListPropertyType = [];
    
    constructor() {
       
    }

    setMinPrice(value) {
        this.minPrice = value;       
    } 

    setMaxPrice(value) {
        this.maxPrice = value;       
    } 

    setBuildingAge(value) {
        this.selectListBuildingAge = value;       
    } 

    setFloorLevel(value) {
        this.selectListFloorLevel = value;       
    }

    setFurniteCondition(value) { 
        this.selectListFurniteCondition = value;         
    } 

    setNumberOfRooms(value) {
        this.selectListNumberOfRooms = value;       
    } 

    setPropertyType(value) {
        this.selectListPropertyType = value;       
    }  

    setSearch(value) {
        this.search= value
        this.pageNumber=1
    } 

    setNextNumber (){
        this.pageNumber+=1;
        ProdStore.getList()
    }
    setPreviosNumber (){
        this.pageNumber = this.pageNumber - 1 <= 1 ? 1 : this.pageNumber - 1
        ProdStore.getList()
    }
    getQueryString(){
        var query = `product?pageNumber=${this.pageNumber}&search=${this.search}&pageSize=${this.pageSize}&minPrice=${this.minPrice}&maxPrice=${this.maxPrice}`;
        
        var result =  this.selectListFurniteCondition.map(num => `furnitureConditionEnum=${num}`).join('&');
        if (!!result) {
            query+='&'+result
        }
        result =  this.selectListFloorLevel.map(num => `floorLevelEnum=${num}`).join('&');
        if (!!result) {
            query+='&'+result
        }
        result = this.selectListNumberOfRooms.map(num => `numberOfRoomsEnum=${num}`).join('&');
        if (!!result) {
            query+='&'+result
        }
        result = this.selectListPropertyType.map(num => `propertyTypeEnum=${num}`).join('&');
        if (!!result) {
            query+='&'+result
        }
        result = this.selectListBuildingAge.map(num => `buildingAgeEnum=${num}`).join('&');
        if (!!result) {
            query+='&'+result
        }

        return query;
    }

}

export default new UserSessionStore(); 
