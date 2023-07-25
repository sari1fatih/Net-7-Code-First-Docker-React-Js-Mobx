import React from 'react'
import { Typography,Grid,CardActionArea} from '@mui/material'; 
import ArrowBackSharpIcon from '@mui/icons-material/ArrowBackSharp';
import ArrowForwardSharpIcon from '@mui/icons-material/ArrowForwardSharp' 
import {observer} from 'mobx-react'
import UserSessionStore from '../stores/UserSessionStore'; 

const LeftRightComp = observer(() => {
    const nextPage = () => {
        UserSessionStore.setNextNumber();    
      }

      const previousPage = () => {
        UserSessionStore.setPreviosNumber();        
      }

  return (
    <Grid container spacing={2}>
    <Grid onClick={previousPage} item xs={6} >
      <CardActionArea style={{ display: 'flex', justifyContent: 'center' }}>
        <Typography variant="h5" component="div">
        <ArrowBackSharpIcon/>
        </Typography>
      </CardActionArea>
    </Grid>
    <Grid onClick={nextPage} item xs={6} style={{display: 'flex', justifyContent: 'center' }}>
    <CardActionArea style={{ display: 'flex', justifyContent: 'center' }}>
      <Typography variant="h5" component="div">
      <ArrowForwardSharpIcon/>
      </Typography>
      </CardActionArea>
    </Grid>
  </Grid>
  )
})

export default LeftRightComp
