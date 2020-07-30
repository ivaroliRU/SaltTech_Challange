import styled from 'styled-components';

export default styled.li`
    z-index: 3;
    color: ${props => (props.active)?"#fff":(props.disabled)?"#6c757d":"212529"};
    background-color: ${props => (props.active)?"#007bff":"#fff"};
    border-color: #007bff;
    position: relative;
    display: block;
    padding: .5rem .75rem;
    margin-left: -1px;
    line-height: 1.25;
    border: 1px solid #dee2e6;

    &:hover {
        cursor: ${props => (props.disabled)?"#initial;":"pointer;"}
        background-color: ${props => (props.disabled)?"#initial;":"#dee2e6;"}
    }
`;