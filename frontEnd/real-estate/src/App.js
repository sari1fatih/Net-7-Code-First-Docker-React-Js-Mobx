
import Products from './pages/products';
import HeaderComp from './components/headerComp';
import FilterComp from './components/filterComp';
import LeftRightComp from './components/leftRightComp';
import './App.css';
import {Routes, Route} from "react-router-dom" 
import { Container,Grid,Box } from '@mui/material';
const App = (() => {
  return (
    <>
        <HeaderComp/>
        <LeftRightComp/>
        <Box sx={{ flexGrow: 1, p: 5}}>
          <Grid container spacing={2} direction="row">            
            <Grid item xs={2} sx={{ flex: '0 0 300px' }}>
              <FilterComp />
            </Grid> 
            <Grid item xs={1} sx={{ flex: '0 0 300px' }}>
               
            </Grid> 
            <Grid item xs={9} sx={{ flexGrow: 1 ,pl:10}}>
              <Container>
                <Routes>
                  <Route path="/" element={<Products />} /> 
                </Routes>
              </Container>
            </Grid>
          </Grid>
        </Box>

   </>
  );
});

export default App;
