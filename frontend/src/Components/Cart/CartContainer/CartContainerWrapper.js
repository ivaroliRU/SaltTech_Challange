import styled from 'styled-components';

export default styled.ul`
    position: absolute;
    right: 20px;
    top: 50px;
    list-style: none;
    z-index: 2;
    background-color: white;
    width: 300px;
    border-radius: 5px;
    padding: 0;
    -webkit-box-shadow: 5px 5px 15px 4px rgba(0,0,0,0.2); 
    box-shadow: 5px 5px 15px 4px rgba(0,0,0,0.2);
    display: ${props => (!props.show)?"none;":"initial;"}
`;