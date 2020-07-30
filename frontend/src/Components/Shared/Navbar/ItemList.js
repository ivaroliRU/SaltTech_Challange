import styled from 'styled-components';

export default styled.ul`
    display: -ms-flexbox;
    display: flex;
    -ms-flex-direction: column;
    flex-direction: column;
    padding-left: 0;
    margin-bottom: 0;
    list-style: none;
    margin-left: ${props => (props.rightAlign)?"auto!important;":"initial;"}
`;