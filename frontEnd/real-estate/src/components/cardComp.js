import * as React from 'react';
import { CardActionArea,Typography, CardMedia,CardContent,Card,Box,Grid} from '@mui/material';
 
const CardComp = ( { data }) => {
  return ( 
    <>
        <Card >
          <CardActionArea>
          <Box sx={{ flexGrow: 1 }} > 
             <Grid container   columns={3} > 
                  <Grid item xs={3} height={100}>
                    <Typography gutterBottom variant="h5" component="div">
                      {data.title}
                    </Typography>
                  </Grid>
                  <Grid item xs={6} height={500} >
                    <CardMedia
                      component="img"
                      height="520"
                      width="396"
                      image= {data.productPhotoUrl}
                      alt="green iguana"
                    />
                 </Grid>
                 <Grid item xs={3} height={220} >
                      <CardContent sx={{ my: 1 }}>
                    
                        <Typography sx={{ my: 1 }} variant="body2" color="text.secondary">
                          {data.description}
                        </Typography>
                        <Typography sx={{ my: 1 }} variant="body2" color="text.secondary">
                          Fiyatı : {data.price} - Metrekare {data.totalSquareFootage}  
                        </Typography>
                        <Typography sx={{ my: 1 }} variant="body2" color="text.secondary">
                          {data.numberOfRoomsEntityValue} Oda ve Binanın Yaşı : {data.buildingAgeEntityValue}  
                        </Typography>
                        <Typography sx={{ my: 1 }} variant="body2" color="text.secondary">
                          {data.propertyTypeEntityValue} - {data.furnitureConditionEntityValue} - {data.floorLevelEntityValue} 
                        </Typography>
                    </CardContent>
                  </Grid>
              </Grid>
            </Box>
          </CardActionArea>
        </Card>
        </>
      ); 
}

export default CardComp
