import styled from 'styled-components';

export default styled.div`
    text-align: center;
    line-height: 40px;
    margin: 0px;
    border-right: ${props => props.divider?"1px solid #ddd":"initial"};

    &:hover {
        cursor: pointer;
        text-decoration: underline;
    }
`;