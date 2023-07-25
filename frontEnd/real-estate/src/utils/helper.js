const helper = {
    findValuesForTrue:(boolList, objList) => {
        const trueIndices = boolList.reduce((indices, item, index) => {
          if (item === true) {
            indices.push(index);
          }
          return indices;
        }, []);
      
        const desiredValues = trueIndices.map(index => {
          if (index < objList.length) {
            return objList[index].value;
          } else {
            return null;
          }
        });
      
        return desiredValues;
      }

}

export default helper