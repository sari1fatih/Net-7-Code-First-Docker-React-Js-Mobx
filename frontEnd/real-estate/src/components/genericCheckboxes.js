import React, { useState } from 'react';
import { Checkbox, FormControlLabel, Box } from '@mui/material';

const GenericCheckboxes = ({ options ,onChange}) => {
  const [checked, setChecked] = useState(Array(options.length).fill(false));

  const handleChange = (event, index) => {
    const newChecked = [...checked];
    newChecked[index] = event.target.checked;
    setChecked(newChecked);
    onChange(newChecked)
   
  };
  
  const isAllSelect = () => {
    return !checked.includes(false)
  }
  const changeAllSelect = (event) => {
    const allTrueList = checked.map(() => event.target.checked);
    setChecked(allTrueList); 
    onChange(allTrueList)
  }

  return (
    <>
       <FormControlLabel
        label="Tümü"
        control={
          <Checkbox
            value={"0"}
            checked={isAllSelect()}
            indeterminate={!isAllSelect()}
            onChange={changeAllSelect}
          />
        }
      />
      
      {options.map((option, index) => (
          <Box sx={{ display: 'flex', flexDirection: 'column', ml: 3 }}>
            <FormControlLabel
            key={index}
            value={option.value}
            label={option.label}
            control={
                <Checkbox checked={checked[index]} onChange={(event) => handleChange(event, index)} />
            }
            />
        </Box>
      ))}
    </>
  );
};

export default GenericCheckboxes;
