import React,{useEffect} from 'react'
import CardComp from '../components/cardComp' 
import {observer} from 'mobx-react'
import ProdStore from '../stores/ProdStore'; 
import Grid from '@mui/material/Grid'; 
import Box from '@mui/material/Box'; 
const Products = observer ( () => {
 
    useEffect(() => { 
      ProdStore.getList()
      
    }, [])
 

  return (  
    <Box>
      <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
        {
           ProdStore?.listProducts?.map((dt,i)=>
           (
            <Grid item xs={5}>
                 <CardComp key={i} data={dt}/>
            </Grid>
           )
         ) 
        } 
      </Grid>
    </Box>
    
);
})

export default Products
