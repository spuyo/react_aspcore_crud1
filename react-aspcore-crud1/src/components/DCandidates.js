import React, {useState, useEffect} from "react"
import {connect} from "react-redux";
import * as actions from "../actions/dCandidate"
import {Button, ButtonGroup, Grid} from "@material-ui/core";
import DCandidateForm from "./DCandidateForm"
import Paper from "@material-ui/core/Paper";
import TableContainer from "@material-ui/core/TableContainer";
import Table from "@material-ui/core/Table";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import {TableCell, withStyles} from "@material-ui/core"
import TableBody from "@material-ui/core/TableBody";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import {useToasts} from "react-toast-notifications"

const styles = theme => ({
    root: {
        "& .MuiTableCell-head": {
            fontSize: "1.25rem"
        }
    },
    paper: {
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    }
})
// props.classes
// const [classes, ...props] = props
const DCandidates = ({classes, ...props}) => {
    const [currentId, setCurrentId] = useState(0)
    /*const [x,setX] = useState(0)
    setX(5) // set x to 5
    useEffect(() => {
       
    }, [x])// do something when x changes*/
    
    useEffect(() => {
        props.fetchAllDCandidates();
    }, [])// like component did mount
    
    // toast message
    const {addToast} = useToasts()
    const onDelete = id => {
        if (window.confirm("Are you sure to delete this record?")){
            props.deleteDCandidate(id, () => addToast("Delete successfully", {appearance: 'info'}))
        }
    }
    
    return (
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item xs={6}>
                    <DCandidateForm {...({currentId, setCurrentId})}/>
                </Grid>
                <Grid item xs={6}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Name</TableCell>
                                    <TableCell>Mobile</TableCell>
                                    <TableCell>Blood Group</TableCell>
                                    <TableCell/>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.dCandidateList.map((record, index) => {
                                        return (
                                            <TableRow key={index} hover>
                                                <TableCell>{record.fullName}</TableCell>
                                                <TableCell>{record.mobile}</TableCell>
                                                <TableCell>{record.bloodGroup}</TableCell>
                                                <TableCell>
                                                    <ButtonGroup variant={"text"}>
                                                        <Button><EditIcon color={"primary"} onClick={() => {setCurrentId(record.id)}}/></Button>
                                                        <Button><DeleteIcon color={"secondary"} onClick={() => onDelete(record.id)}/></Button>
                                                    </ButtonGroup>
                                                </TableCell>
                                            </TableRow>
                                        )
                                    })
                                }
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </Grid>
        </Paper>
    );
}

const mapStateToProps = state => ({
    dCandidateList: state.dCandidate.list
})

const mapActionToProps = {
    fetchAllDCandidates: actions.fetchAll,
    deleteDCandidate: actions.Delete
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(DCandidates));