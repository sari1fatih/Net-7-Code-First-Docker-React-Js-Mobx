import React,{useState} from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import TextField from '@mui/material/TextField';
import {observer} from 'mobx-react'
import ProdStore from '../stores/ProdStore'; 
import UserSessionStore from '../stores/UserSessionStore'; 

const HeaderComp = observer(() => {
 
  const onChange = (event) => {
    var text=event.target.value;
    UserSessionStore.setSearch(text);
    ProdStore.getList();
  };
  return (
    <AppBar position="static">
      <Toolbar style={{ display: 'flex', justifyContent: 'space-between' }}>
        <div style={{ display: 'flex', alignItems: 'center' }}>
          <Typography variant="h6" style={{ marginRight: '20px' }}>
            Real Estate
          </Typography>
        </div>
        <TextField
          variant="outlined"
          size="small"
          placeholder="Ara..."
          onChange={onChange}
          style={{ flex: 1, backgroundColor: 'white',placeholderTextColor:'grey' }}
        />
      </Toolbar>
    </AppBar>
  );
});

export default HeaderComp;