import React from 'react'; 
import GenericCheckboxes from './genericCheckboxes';
import Helper from '../utils/helper'; 
import { propertyType,furnitureCondition,numberOfRooms,floorLevel,buildingAgeEntity } from '../utils/global'; 
import UserSessionStore from '../stores/UserSessionStore'; 
import ProdStore from '../stores/ProdStore';  
import TextField from '@mui/material/TextField'; 
import FormControl from '@mui/material/FormControl';
import FormLabel from '@mui/material/FormLabel';

const FilterComp = (() => {

  const handleFurnitureConditionChange = (checked) => {
    const result = Helper.findValuesForTrue( checked,furnitureCondition); 
    UserSessionStore.setFurniteCondition(result)
    getProducts();
  };

  const handlePropertyTypeChange = (checked) => {
    const result = Helper.findValuesForTrue( checked,propertyType); 
    UserSessionStore.setPropertyType(result)
    getProducts();
  };

  const handleNumberOfRoomsChange = (checked) => {
    const result = Helper.findValuesForTrue( checked,numberOfRooms); 
    UserSessionStore.setNumberOfRooms(result)
    getProducts();
  };

  const handleFloorLevelChange = (checked) => {
    const result = Helper.findValuesForTrue( checked,floorLevel); 
    UserSessionStore.setFloorLevel(result)
    getProducts();
  };

  const handleBuildingAgeEntityChange = (checked) => {
    const result = Helper.findValuesForTrue( checked,buildingAgeEntity); 
    UserSessionStore.setBuildingAge(result)
    getProducts();
  };


  const getProducts = () => {
    ProdStore.getList();
  };

  const onMinChange = (event) => {
    var text=event.target.value;
    UserSessionStore.setMinPrice(text);
    ProdStore.getList();
  };

  const onMaxChange = (event) => {
    var text=event.target.value;
    UserSessionStore.setMaxPrice(text);
    ProdStore.getList();
  };
 
  return (
    <div style={{justifyContent:'center',width:'200px', paddingLeft:'10px' }}>
    
      <FormControl sx={{my:1}}>
        <FormLabel id="demo-radio-buttons-group-label">Fiyat Aralığı</FormLabel>
          <TextField  InputProps={{
              inputProps: { 
                  min: 0
              }
              }} onChange={onMinChange} type="number" sx={{my:2}} id="outlined-basic" label="Minumum" variant="outlined" />
          <TextField InputProps={{
              inputProps: { 
                  max: 150000
              }
          }} onChange={onMaxChange} type="number" id="outlined-basic" label="Maximum" variant="outlined" />
      </FormControl>

      <GenericCheckboxes options={propertyType}  onChange={handlePropertyTypeChange}/>
      <GenericCheckboxes options={furnitureCondition}  onChange={handleFurnitureConditionChange}/>
      <GenericCheckboxes options={numberOfRooms}  onChange={handleNumberOfRoomsChange}/>
      <GenericCheckboxes options={floorLevel}  onChange={handleFloorLevelChange}/>
      <GenericCheckboxes options={buildingAgeEntity}  onChange={handleBuildingAgeEntityChange}/>
        
    </div>
  );
});

export default FilterComp;
