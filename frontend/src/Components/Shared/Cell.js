import styled from 'styled-components';

export default styled.div`
    flex: 0 0 ${props => props.size?(props.size/12)*100:"25"}%;
    max-width: ${props => props.size?(props.size/12)*100:"25"}%;
    padding-right: 15px;
    padding-left: 15px;
`;